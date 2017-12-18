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

        //Makes the context avalible in the class
        public SingleRoomRepository(HotelExamContext context)
        {
            this.context = context;
        }

        //Add a singleroom to the context
        public SingleRoom Create(SingleRoom singleRoom)
        {
            context.SingleRooms.Add(singleRoom);
            return singleRoom;
        }

        //Remove a singleroom from the context by it's id if it exists
        public SingleRoom Delete(int Id)
        {
            var singleRoom = Get(Id);
            if (singleRoom != null)
            {
                context.SingleRooms.Remove(singleRoom);
            }

            return singleRoom;
        }

        //Get a singleroom from the context by it's id
        public SingleRoom Get(int Id) => context.SingleRooms.FirstOrDefault(s => s.Id == Id);

        //Get all singlerooms from the context as a list
        public IEnumerable<SingleRoom> GetAll() => context.SingleRooms.ToList();
    }
}