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
        private BookingConverter bConv;

        public GuestConverter()
        {
            bConv = new BookingConverter();
        }

        public Guest Convert(GuestBO guest)
        {
            if (guest == null) { return null; }
            return new Guest()
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Address = guest.Address,
                Bookings = guest.BookingIds?.Select(bId => new Booking()
                {
                    Id = bId,
                    GuestId = guest.Id
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
                //Bookings = guest.Bookings?.Select(b => new BookingBO()
                //{
                //    Id = b.Id,
                //    CheckIn = b.CheckIn,
                //    CheckOut = b.CheckOut

                //}).ToList()
            };
        }
    }
}
