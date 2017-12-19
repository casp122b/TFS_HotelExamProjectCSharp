using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class BookingRepository: IRepository<Booking>
    {
        HotelExamContext context;

        // Makes the context available in the class
        public BookingRepository(HotelExamContext context)
        {
            this.context = context;
        }

        // Add a booking to the context
        public Booking Create(Booking book)
        {
            context.Bookings.Add(book);
            return book;
        }

        // Remove a booking from the context by it's id if it exists
        public Booking Delete(int Id)
        {
            var book = Get(Id);
            if (book != null)
            {
                context.Bookings.Remove(book);
            }

            return book;
        }

        // Get a booking from the context by it's id
        public Booking Get(int Id) => context.Bookings.FirstOrDefault(b => b.Id == Id);

        // Get all bookings from the context as a list
        public IEnumerable<Booking> GetAll() => context.Bookings.ToList();
    }
}