using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
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
            _context.Doubles.Add(doubleRoom);
            return doubleRoom;
        }

        public DoubleRoom Delete(int Id)
        {
            var doubleRoom = Get(Id);
            if (doubleRoom != null)
            {
                _context.Doubles.Remove(doubleRoom);
            }
            return doubleRoom;
        }

        public DoubleRoom Get(int Id)
        {
            return _context.Doubles.FirstOrDefault(d => d.Id == Id);
        }

        public IEnumerable<DoubleRoom> GetAll()
        {
            return _context.Doubles.ToList();
        }
    }
}
