using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class BookingConverter: IConverter<Booking, BookingBO>
    {
        SingleRoomConverter singleConv;
        DoubleRoomConverter doubleConv;
        SuiteConverter suiteConv;
        UserConverter userConv;

        public BookingConverter()
        {
            singleConv = new SingleRoomConverter();
            doubleConv = new DoubleRoomConverter();
            suiteConv = new SuiteConverter();
            userConv = new UserConverter();
        }

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
                UserId = book.UserId
            };
        }

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
                User = userConv.Convert(book.User),
                SingleRoomId = book.SingleRoomId,
                DoubleRoomId = book.DoubleRoomId,
                SuiteId = book.SuiteId,
                UserId = book.UserId
            };
        }
    }
}