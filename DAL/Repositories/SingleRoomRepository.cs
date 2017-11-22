using DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class SingleRoomRepository : IRepository<SingleRoom>
    {
        HotelExamContext _context;
        public SingleRoomRepository(HotelExamContext context)
        {
            _context = context;
        }

        public SingleRoom Create(SingleRoom single)
        {
            _context.Singles.Add(single);
            return single;
        }

        public SingleRoom Delete(int Id)
        {
            var single = Get(Id);
            if (single != null)
            {
                _context.Singles.Remove(single);
            }
            return single;
        }

        public SingleRoom Get(int Id)
        {
            return _context.Singles.FirstOrDefault(s => s.Id == Id);
        }

        public IEnumerable<SingleRoom> GetAll()
        {
            return _context.Singles.ToList();
        }
    }
}
