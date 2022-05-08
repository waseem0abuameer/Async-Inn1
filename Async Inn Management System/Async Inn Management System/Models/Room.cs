using System;
using System.Collections.Generic;

namespace Async_Inn_Management_System.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }
        //0 OneBedroom
        //1 TwoBedroom
        //2 Studio
        public ICollection<HotelRoom> HotelRooms { get; set; }
        public List<RoomAmenities> RoomAmenities { get; set; }


    }
}
