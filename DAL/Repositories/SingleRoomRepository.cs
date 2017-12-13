using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class SingleRoomRepository: IRepository<SingleRoom>
    {
        HotelExamContext context;
        public SingleRoomRepository(HotelExamContext context)
        {
            this.context = context;
        }

        public SingleRoom Create(SingleRoom singleRoom)
        {
            context.SingleRooms.Add(singleRoom);
            return singleRoom;
        }

        public SingleRoom Delete(int Id)
        {
            var singleRoom = Get(Id);
            if (singleRoom != null)
            {
                context.SingleRooms.Remove(singleRoom);
            }

            return singleRoom;
        }

        public SingleRoom Get(int Id) => context.SingleRooms.FirstOrDefault(s => s.Id == Id);

        public IEnumerable<SingleRoom> GetAll() => context.SingleRooms.ToList();
    }
}