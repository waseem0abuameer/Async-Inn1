using Async_Inn_Management_System.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IRoom
    {
        Task<RoomDTO> CreateRoom(RoomDTO room);
        Task<RoomDTO> GetRoom(int Id);
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> UpdateRoom(int ID, RoomDTO room);
        Task DeleteRoom(int Id);
        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
