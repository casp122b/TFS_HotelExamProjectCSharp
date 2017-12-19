using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class BookingConverter: IConverter<Booking, BookingBO>
    {
        SingleRoomConverter singleConv;
        DoubleRoomConverter doubleConv;
        SuiteConverter suiteConv;
        GuestConverter guestConv;

        public BookingConverter()
        {
            singleConv = new SingleRoomConverter();
            doubleConv = new DoubleRoomConverter();
            suiteConv = new SuiteConverter();
            guestConv = new GuestConverter();
        }

        // Converts bookingBO to booking
        public Booking Convert(BookingBO book)
        {
            if (book == null)
            {
                return null;
            }

            return new Booking()
            {
                Id = book.Id,
                CheckIn = book.CheckIn,
                CheckOut = book.CheckOut,
                SingleRoomId = book.SingleRoomId,
                DoubleRoomId = book.DoubleRoomId,
                SuiteId = book.SuiteId,
                GuestId = book.GuestId
            };
        }

        // Converts booking to bookingBO
        public BookingBO Convert(Booking book)
        {
            if (book == null)
            {
                return null;
            }

            return new BookingBO()
            {
                Id = book.Id,
                CheckIn = book.CheckIn,
                CheckOut = book.CheckOut,
                SingleRoom = singleConv.Convert(book.SingleRoom),
                DoubleRoom = doubleConv.Convert(book.DoubleRoom),
                Suite = suiteConv.Convert(book.Suite),
                Guest = guestConv.Convert(book.Guest),
                SingleRoomId = book.SingleRoomId,
                DoubleRoomId = book.DoubleRoomId,
                SuiteId = book.SuiteId,
                GuestId = book.GuestId
            };
        }
    }
}