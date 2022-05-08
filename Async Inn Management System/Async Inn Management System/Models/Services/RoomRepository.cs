using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Services
{
    public class RoomRepository : IRoom
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Room> CreateRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task DeleteRoom(int Id)
        {
            Room room = await GetRoom(Id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int Id)
        {
            //Room room = await _context.Rooms.FindAsync(Id);
            //return room;
            //Room room= await _context.Rooms.FindAsync(Id);
            //var hotelroom = await _context.HotelRooms
            //   .Where(r => r.RoomID == Id)
            //   .Include(h => h.Hotel)

            //   .ToListAsync();
            //room.HotelRooms = hotelroom;

            //return room;
            return await _context.Rooms
            .Include(rh => rh.HotelRooms)
            .ThenInclude(h => h.Hotel).FirstOrDefaultAsync(x => x.ID == Id);
        }

        public async Task<List<Room>> GetRooms()
        {
            //var rooms = await _context.Rooms.ToListAsync();
            //return rooms;
            return await _context.Rooms
          .Include(rh => rh.HotelRooms)
          .ToListAsync();
        }

        public async Task<Room> UpdateRoom(int ID, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = new RoomAmenities()
            {
                RoomID = roomId,
                AmenitiesID = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenities = await _context.RoomAmenities.Where(x => x.AmenitiesID == amenityId && x.RoomID == roomId).FirstOrDefaultAsync();

            _context.Entry(roomAmenities).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

    }
}
