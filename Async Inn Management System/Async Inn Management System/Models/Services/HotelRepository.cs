using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Services
{
   

    public class HotelRepository:IHotel
    {
        private readonly HotelDbContext _context;
        public HotelRepository(HotelDbContext context)
        {
            _context= context;
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotel(int Id)
        {
            Hotel hotel = await GetHotel(Id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int Id)
        {
            //Hotel hotel = await _context.Hotels.FindAsync(Id);
            //return hotel;
            return await _context.Hotels
            .Include(rh => rh.HotelRooms)
            .ThenInclude(h => h.Room).FirstOrDefaultAsync(x => x.ID == Id);

        }

        public async Task<List<Hotel>> GetHotels()
        {
            //var hotels = await _context.Hotels.ToListAsync();
            //return hotels;
            return await _context.Hotels
            .Include(rh => rh.HotelRooms)
            .ToListAsync();
        }

        public async Task<Hotel> UpdateHotel(int Id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
        public async Task AddRoomsToHotel(int hotelId , int roomId)
        {
            HotelRoom hotelroom = new HotelRoom()
            {
                RoomID = roomId,
                HotelID = hotelId
            };

            _context.Entry(hotelroom).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }
        //public async Task RemoveRoomsToHotel(int roomId, int amenityId)
        //{
        //    RoomAmenities roomAmenities = await _context.RoomAmenities.Where(x => x.AmenitiesID == amenityId && x.RoomID == roomId).FirstOrDefaultAsync();

        //    _context.Entry(roomAmenities).State = EntityState.Deleted;

        //    await _context.SaveChangesAsync();
        //}
    }
}
