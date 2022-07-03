using System;
using System.Threading.Tasks;
using Xunit;

using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.DTOs;
using Async_Inn_Management_System.Models.Services;
using Async_Inn_Management_System.Models.Services;
namespace TestHotel1
{
    public class UnitTest1:Mock
    {
        [Fact]
        public async Task Can_enroll_and_drop_a_Hotel()
        {
            // Arrange
            var room = await CreateAndSaveTestRoom();
            var amenity = await CreateAndSaveTestAmenity();

            var Repository = new RoomRepository(_db);

            // Act
            await Repository.AddAmenityToRoom(room.ID, amenity.ID);

            // Assert
            var actualRoom = await Repository.GetRoom(room.ID);

            Assert.Contains(actualRoom.Amenities, a => a.ID == amenity.ID);

            // Act
            await Repository.RemoveAmentityFromRoom(room.ID, amenity.ID);

            // Assert
            actualRoom = await Repository.GetRoom(room.ID);

            Assert.DoesNotContain(actualRoom.Amenities, a => a.ID == amenity.ID);



        }
    }
}
