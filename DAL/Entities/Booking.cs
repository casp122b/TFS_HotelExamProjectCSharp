using System;

namespace DAL.Entities
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
