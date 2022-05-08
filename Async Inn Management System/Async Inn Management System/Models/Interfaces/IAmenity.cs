using Async_Inn_Management_System.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IAmenity
    {
        Task<AmenityDTO> CreateAmenity(AmenityDTO amenity);
        Task<AmenityDTO> GetAmenity(int Id);
        Task<List<AmenityDTO>> GetAmenities();
        Task<AmenityDTO> UpdateAmenity(int Id, AmenityDTO amenity);
        Task DeleteAmenity(int Id);
    }
}
