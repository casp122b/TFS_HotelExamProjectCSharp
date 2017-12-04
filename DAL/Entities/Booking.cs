using System;

namespace DAL.Entities
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int SingleRoomId { get; set;}
        public int DoubleRoomId { get; set; }
        public int SuiteId { get; set; }
        public SingleRoom SingleRoom { get; set; }
        public DoubleRoom DoubleRoom { get; set; }
        public Suite Suite { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
    }
}
