using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Async_Inn_Management_System;
using Async_Inn_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.Services;
using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestHotel1
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly HotelDbContext _db;
   
        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new HotelDbContext(
                new DbContextOptionsBuilder<HotelDbContext>()
                    .UseSqlite(_connection)
                    .Options);
          
            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
     
        protected async Task<Room> CreateAndSaveTestRoom()
        {
            var room = new Room { Name = "RoomTest", Layout = 1 };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.ID); // Sanity check
            return room;
        }

        protected async Task<Amenity> CreateAndSaveTestAmenity()
        {
            var amenity = new Amenity { Name = "AmenityTest" };
            _db.Amenities.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.ID); // Sanity check
            return amenity;
        }
    }
}
