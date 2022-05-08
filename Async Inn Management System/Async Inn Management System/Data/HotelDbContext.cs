using Async_Inn_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Amenity> Amenities { get; set; }       
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }

        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel { ID = 1, Name = "Async Inn-Irbid", Address = "Irbid", City = "Irbid", State = "jordan", Phone = "02665200" },
                         new Hotel { ID = 2, Name = "Async Inn-WadiRum", Address = "WadiRum", City = "Aqaba", State = "jordan", Phone = "02665201" },
                         new Hotel { ID = 3, Name = "Async Inn-Amman", Address = "Amman", City= "Amman", State = "jordan", Phone = "02665202" }
                         );
            modelBuilder.Entity<Room>()
                .HasData(new Room { ID = 1, Name = "One Bedrooms ", Layout = 0 },
                         new Room { ID = 2, Name = "Two Bedrooms", Layout = 1 },
                         new Room { ID = 3, Name = "Studio", Layout = 2 }
                         );

            modelBuilder.Entity<Amenity>()
                .HasData(new Amenity { ID = 1, Name = " air conditioner" },
                         new Amenity { ID = 2, Name = "television" },
                         new Amenity { ID = 3, Name = "look" },
                        new Amenity { ID = 4, Name = "Children's bed" }
                         );

            modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelID, x.RoomID });
            modelBuilder.Entity<RoomAmenities>().HasKey(x => new { x.AmenitiesID, x.RoomID });



        }

    }
}
