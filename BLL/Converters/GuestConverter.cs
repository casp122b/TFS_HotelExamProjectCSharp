using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Converters
{
    public class GuestConverter : IConverter<Guest, GuestBO>
    {
        public Guest Convert(GuestBO guestBO)
        {
            if (guestBO == null) { return null; }
            return new Guest()
            {
                Id = guestBO.Id,
                FirstName = guestBO.FirstName,
                LastName = guestBO.LastName,
                Address = guestBO.Address,
                Bookings = guestBO.BookingIds?.Select(bId => new Booking()
                {
                    Id = bId,
                    GuestId = guestBO.Id
                }).ToList()

            };
        }

        public GuestBO Convert(Guest guest)
        {
            if (guest == null) { return null; }
            return new GuestBO()
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Address = guest.Address,
                BookingIds = guest.Bookings?.Select(b => b.Id).ToList()
            };
        }
    }
}
