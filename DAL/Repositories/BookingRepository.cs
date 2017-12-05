using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        HotelExamContext _context;
        public BookingRepository(HotelExamContext context)
        {
            _context = context;
        }

        public Booking Create(Booking book)
        {
            _context.Bookings.Add(book);
            return book;
        }

        public Booking Delete(int Id)
        {
            var book = Get(Id);
            if (book != null)
            {
                _context.Bookings.Remove(book);
            }
            return book;
        }

        public Booking Get(int Id)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == Id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public IEnumerable<Booking> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; };

            return _context.Bookings.Where(b => ids.Contains(b.Id));
        }
    }
}
