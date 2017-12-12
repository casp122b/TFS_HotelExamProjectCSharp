using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class DoubleRoomRepository: IRepository<DoubleRoom>
    {
        HotelExamContext context;
        public DoubleRoomRepository(HotelExamContext context)
        {
            this.context = context;
        }

        public DoubleRoom Create(DoubleRoom doubleRoom)
        {
            context.DoubleRooms.Add(doubleRoom);
            return doubleRoom;
        }

        public DoubleRoom Delete(int Id)
        {
            var doubleRoom = Get(Id);
            if (doubleRoom != null)
            {
                context.DoubleRooms.Remove(doubleRoom);
            }

            return doubleRoom;
        }

        public DoubleRoom Get(int Id) => context.DoubleRooms.FirstOrDefault(d => d.Id == Id);

        public IEnumerable<DoubleRoom> GetAll() => context.DoubleRooms.ToList();
    }
}