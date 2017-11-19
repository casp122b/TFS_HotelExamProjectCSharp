using System.Collections.Generic;
using DAL.Context;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        HotelExamContext _context;
        public RoomRepository(HotelExamContext context)
        {
            _context = context;
        }

        public Room Create(Room room)
        {
            _context.Rooms.Add(room);
            return room;
        }

        public List<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }
    }
}
