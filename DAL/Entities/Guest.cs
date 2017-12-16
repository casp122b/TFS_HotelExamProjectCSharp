using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Guest
    {
        [Key]
        public int? Id
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
        public int UserId
        {
            get; set;
        }
        public User User
        {
            get; set;
        }
        public List<SingleRoom> SingleRooms
        {
            get; set;
        }
        public List<DoubleRoom> DoubleRooms
        {
            get; set;
        }
        public List<Suite> Suites
        {
            get; set;
        }
        public List<Booking> Bookings
        {
            get; set;
        }
    }
}