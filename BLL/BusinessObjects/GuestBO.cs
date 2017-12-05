using System.Collections.Generic;

namespace BLL.BusinessObjects
{
    public class GuestBO : IBusinessObject
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<int> BookingIds { get; set; }
        public List<BookingBO> Bookings { get; set; }
    }
}
