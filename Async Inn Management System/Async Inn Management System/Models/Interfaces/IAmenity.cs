using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> CreateAmenity(Amenity amenity);
        Task<Amenity> GetAmenity(int Id);
        Task<List<Amenity>> GetAmenities();
        Task<Amenity> UpdateAmenity(int Id, Amenity amenity);
        Task DeleteAmenity(int Id);
    }
}
