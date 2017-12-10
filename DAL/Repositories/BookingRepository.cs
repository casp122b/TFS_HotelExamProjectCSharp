using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class BookingRepository: IRepository<Booking>
    {
        HotelExamContext context;
        public BookingRepository(HotelExamContext context)
        {
            this.context = context;
        }

        public Booking Create(Booking book)
        {
            context.Bookings.Add(book);
            return book;
        }

        public Booking Delete(int Id)
        {
            var book = Get(Id);
            if (book != null)
            {
                context.Bookings.Remove(book);
            }

            return book;
        }

        public Booking Get(int Id) => context.Bookings.FirstOrDefault(b => b.Id == Id);

        public IEnumerable<Booking> GetAll() => context.Bookings.ToList();
    }
}