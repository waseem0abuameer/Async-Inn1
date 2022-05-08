using Async_Inn_Management_System.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotel
    {

        Task<HotelDTO> CreateHotel(HotelDTO hotel);
        Task<HotelDTO> GetHotel(int Id);
        Task<List<HotelDTO>> GetHotels();
        Task<HotelDTO> UpdateHotel(int Id, HotelDTO hotel);
        Task DeleteHotel(int Id);
    }
}
