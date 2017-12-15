using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Admin: IPerson
    {
        [Key]
        public int Id
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
        public List<Booking> Bookings
        {
            get; set;
        }
    }
}