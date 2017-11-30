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
                CheckOut = book.CheckOut,
                SingleRoomId = book.SingleRoomId,
                DoubleRoomId = book.DoubleRoomId,
                SuiteId = book.SuiteId
            };
        }

        public BookingBO Convert(Booking book)
        {
            if (book == null) { return null; }
            return new BookingBO()
            {
                Id = book.Id,
                CheckIn = book.CheckIn,
                CheckOut = book.CheckOut,
                SingleRoom = new SingleRoomConverter().Convert(book.SingleRoom),
                DoubleRoom = new DoubleRoomConverter().Convert(book.DoubleRoom),
                Suite = new SuiteConverter().Convert(book.Suite),
                SingleRoomId = book.SingleRoomId,
                DoubleRoomId = book.DoubleRoomId,
                SuiteId = book.SuiteId
            };
        }
    }
}
