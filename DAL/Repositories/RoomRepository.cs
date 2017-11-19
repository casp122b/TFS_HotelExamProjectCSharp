using System.Collections.Generic;
using DAL.Context;
using DAL.Entities;
using System.Linq;
using System;

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
            Console.WriteLine("Repository" + " " + room);
            return room;
        }

        public List<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room Update(Room room)
        {
            _context.Rooms.Update(room);
            Console.WriteLine("Repository" + " " + room);
            return room;
        }
    }
}
