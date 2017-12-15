using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class SingleRoom: IRoom
    {
        [Key]
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public double Price
        {
            get; set;
        }
        public bool Available
        {
            get; set;
        }
        public int? GuestId
        {
            get; set;
        }
        public Guest Guest
        {
            get; set;
        }
        public List<Booking> Bookings
        {
            get; set;
        }
    }
}