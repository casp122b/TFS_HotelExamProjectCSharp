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

        public SingleRoom Create(SingleRoom singleRoom)
        {
            _context.SingleRooms.Add(singleRoom);
            return singleRoom;
        }

        public SingleRoom Delete(int Id)
        {
            var singleRoom = Get(Id);
            if (singleRoom != null)
            {
                _context.SingleRooms.Remove(singleRoom);
            }
            return singleRoom;
        }

        public SingleRoom Get(int Id)
        {
            return _context.SingleRooms.FirstOrDefault(s => s.Id == Id);
        }

        public IEnumerable<SingleRoom> GetAll()
        {
            return _context.SingleRooms.ToList();
        }

        public IEnumerable<SingleRoom> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
