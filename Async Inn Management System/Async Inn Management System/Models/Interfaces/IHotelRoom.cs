using Async_Inn_Management_System.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoom);
        Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber);
        Task<List<HotelRoomDTO>> GetHotelRooms();
        Task<HotelRoomDTO> UpdateHotelRoom(HotelRoomDTO hotelRoom);
        Task DeleteHotelRoom(int hotelId, int roomNumber);

        //Task AddRoomToHotel(int roomId, int hotelId);

       //  Task RemoveRoomFromHotel(int roomId, int hotelId);
    }
}
