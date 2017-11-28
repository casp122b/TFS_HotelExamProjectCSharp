using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class BookingConverter : IConverter<Booking, BookingBO>
    {
        public Booking Convert(BookingBO book)
        {
            if (book == null) { return null; }
            return new Booking()
            {
                Id = book.Id,
                CheckIn = book.CheckIn,
                CheckOut = book.CheckOut
            };
        }

        public BookingBO Convert(Booking book)
        {
            if (book == null) { return null; }
            return new BookingBO()
            {
                Id = book.Id,
                CheckIn = book.CheckIn,
                CheckOut = book.CheckOut
            };
        }
    }
}
