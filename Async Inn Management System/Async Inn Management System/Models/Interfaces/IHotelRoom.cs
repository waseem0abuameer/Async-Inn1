﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom);
        Task DeleteHotelRoom(int hotelId, int roomNumber);

        Task AddRoomToHotel(int roomId, int hotelId);

        Task RemoveRoomFromHotel(int roomId, int hotelId);
    }
}
