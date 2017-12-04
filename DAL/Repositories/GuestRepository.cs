using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GuestRepository : IRepository<Guest>
    {
        HotelExamContext _context;
        public GuestRepository(HotelExamContext context)
        {
            _context = context;
        }

        public Guest Create(Guest guest)
        {
            _context.Guests.Add(guest);
            return guest;
        }

        public Guest Delete(int Id)
        {
            var guest = Get(Id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
            }
            return guest;
        }

        public Guest Get(int Id)
        {
            return _context.Guests.Include(g => g.Bookings).FirstOrDefault(g => g.Id == Id);
        }

        public IEnumerable<Guest> GetAll()
        {
            return _context.Guests
                .Include(g => g.Bookings)
                .ToList();
        }
    }
}
