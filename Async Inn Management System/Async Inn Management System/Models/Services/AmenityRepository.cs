using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTOs;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Services
{
    public class AmenityRepository: IAmenity
    {
        private readonly HotelDbContext _context;

        public AmenityRepository(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<AmenityDTO> CreateAmenity(AmenityDTO amenity)
        {
            Amenity NAmenity = new Amenity
            {
                ID = amenity.ID,
                Name = amenity.Name
            };
            _context.Entry(NAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task DeleteAmenity(int Id)
        {
            AmenityDTO amenity = await GetAmenity(Id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            return await _context.Amenities.Select(amenity => new AmenityDTO
            {
                ID = amenity.ID,
                Name = amenity.Name
            }).ToListAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int Id)
        {
            return await _context.Amenities.Select(amenity => new AmenityDTO
            {
                ID = amenity.ID,
                Name = amenity.Name
            }).FirstOrDefaultAsync(a => a.ID == Id);
        }

        public async Task<AmenityDTO> UpdateAmenity(int Id, AmenityDTO amenity)
        {
            Amenity updateAmenity = new Amenity
            {
                ID = amenity.ID,
                Name = amenity.Name
            };
            _context.Entry(updateAmenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
