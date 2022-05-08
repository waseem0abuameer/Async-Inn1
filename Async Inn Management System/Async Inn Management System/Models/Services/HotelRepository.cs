﻿using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTOs;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<HotelDTO> CreateHotel(HotelDTO hotel)
        {
            Hotel newHotel = new Hotel
            {
                ID = hotel.ID,
                Name = hotel.Name,
                Address = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };
            _context.Entry(newHotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotel(int Id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(Id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetHotel(int Id)
        {
            return await _context.Hotels.Select(x => new HotelDTO
            {
                ID = x.ID,
                Name = x.Name,
                StreetAddress = x.Address,
                City = x.City,
                State = x.State,
                Phone = x.Phone,
                Rooms = x.HotelRooms.Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelID,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    PetFriendly = x.PetFriendly,
                    RoomID = x.RoomID,
                    Room = x.Room.HotelRooms.Select(x => new RoomDTO
                    {
                        ID = x.Room.ID,
                        Name = x.Room.Name,
                        Layout = x.Room.Layout,
                        Amenities = x.Room.RoomAmenities.Select(x => new AmenityDTO
                        {
                            ID = x.Amenities.ID,
                            Name = x.Amenities.Name
                        }).ToList()
                    }).FirstOrDefault()
                }).ToList()
            }).FirstOrDefaultAsync(x => x.ID == Id);
        }

        public async Task<List<HotelDTO>> GetHotels()
        {
            return await _context.Hotels.Select(x => new HotelDTO
            {
                ID = x.ID,
                Name = x.Name,
                StreetAddress = x.Address,
                City = x.City,
                State = x.State,
                Phone = x.Phone,
                Rooms = x.HotelRooms.Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelID,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    PetFriendly = x.PetFriendly,
                    RoomID = x.RoomID,
                    Room = x.Room.HotelRooms.Select(x => new RoomDTO
                    {
                        ID = x.Room.ID,
                        Name = x.Room.Name,
                        Layout = x.Room.Layout,
                        Amenities = x.Room.RoomAmenities.Select(x => new AmenityDTO
                        {
                            ID = x.Amenities.ID,
                            Name = x.Amenities.Name
                        }).ToList()
                    }).FirstOrDefault()
                }).ToList()
            }).ToListAsync();
        }

        public async Task<HotelDTO> UpdateHotel(int Id, HotelDTO hotel)
        {
            Hotel updateHotel = new Hotel
            {
                ID = hotel.ID,
                Name = hotel.Name,
                Address = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };
            _context.Entry(updateHotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
