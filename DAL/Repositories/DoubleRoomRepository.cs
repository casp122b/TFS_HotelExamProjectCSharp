using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class DoubleRoomRepository : IRepository<DoubleRoom>
    {
        HotelExamContext _context;
        public DoubleRoomRepository(HotelExamContext context)
        {
            _context = context;
        }

        public DoubleRoom Create(DoubleRoom doubleRoom)
        {
            _context.DoubleRooms.Add(doubleRoom);
            return doubleRoom;
        }

        public DoubleRoom Delete(int Id)
        {
            var doubleRoom = Get(Id);
            if (doubleRoom != null)
            {
                _context.DoubleRooms.Remove(doubleRoom);
            }
            return doubleRoom;
        }

        public DoubleRoom Get(int Id)
        {
            return _context.DoubleRooms.FirstOrDefault(d => d.Id == Id);
        }

        public IEnumerable<DoubleRoom> GetAll()
        {
            return _context.DoubleRooms.Include(s => s.Guest).ToList();
        }
    }
}
