using System.Collections.Generic;

namespace Async_Inn_Management_System.Models
{
    public class Amenity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<RoomAmenities> RoomAmenities { get; set; }

    }
}
