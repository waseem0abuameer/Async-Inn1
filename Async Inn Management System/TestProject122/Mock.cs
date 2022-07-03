using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject122
{
    internal class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly HotelDbContext _db;
        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new HotelDbContext(
                new DbContextOptionsBuilder<HotelDbContext>()
                    .UseSqlServer(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
        protected async Task<Amenity> CreateAndSaveAmenity()
        {
            var amenity = new Amenity { ID = 5, Name = "dfars" };
            _db.Amenities.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.ID);
            return amenity;
        }

        protected async Task<Room> CreateAndSaveRoom()
        {
            var room = new Room { ID = 5, Name = "cozy studio", Layout = 0 };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.ID);
            return room;
        }

    }
}
