using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class BookingConverter : IConverter<Booking, BookingBO>
    {
        private SingleRoomConverter sconv;
        private DoubleRoomConverter dconv;
        private SuiteConverter suiteconv;

        public BookingConverter()
        {
            sconv = new SingleRoomConverter();
            dconv = new DoubleRoomConverter();
            suiteconv = new SuiteConverter();
        }

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
                SingleRoom = sconv.Convert(book.SingleRoom),
                DoubleRoom = dconv.Convert(book.DoubleRoom),
                Suite = suiteconv.Convert(book.Suite),
                SingleRoomId = book.SingleRoomId,
                DoubleRoomId = book.DoubleRoomId,
                SuiteId = book.SuiteId
            };
        }
    }
}
