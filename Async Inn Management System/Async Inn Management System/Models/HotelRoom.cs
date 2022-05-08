namespace Async_Inn_Management_System.Models
{
    public class HotelRoom
    {
        public int ID { get; set; }

        public int RoomNumber { get; set; }       
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public int RoomID { get; set; }
        public int HotelID { get; set; }

        // NAV PROP
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
