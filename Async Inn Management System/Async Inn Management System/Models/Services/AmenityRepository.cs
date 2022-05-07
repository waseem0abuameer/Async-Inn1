using Async_Inn_Management_System.Data;
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
        public async Task<Amenity> CreateAmenity(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task DeleteAmenity(int Id)
        {
            Amenity amenity = await GetAmenity(Id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenity = await _context.Amenities.ToListAsync();
            return amenity;
        }

        public async Task<Amenity> GetAmenity(int Id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(Id);
            return amenity;
        }

        public async Task<Amenity> UpdateAmenity(int Id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
