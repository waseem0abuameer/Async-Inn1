namespace Async_Inn_Management_System.Models
{
    public class RoomAmenities
    {
        public int AmenitiesID { get; set; }
        public int RoomID { get; set; }

        //Navigation Properties

        public Amenity Amenities { get; set; }
        public Room Room { get; set; }
    }
}
