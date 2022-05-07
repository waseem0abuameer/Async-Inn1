using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> CreateRoom(Room room);
        Task<Room> GetRoom(int Id);
        Task<List<Room>> GetRooms();
        Task<Room> UpdateRoom(int ID, Room room);
        Task DeleteRoom(int Id);
    }
}
