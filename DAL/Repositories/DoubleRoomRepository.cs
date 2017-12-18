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

        //Makes the context avalible in the class
        public DoubleRoomRepository(HotelExamContext context)
        {
            this.context = context;
        }

        //Add a doubleroom to the context
        public DoubleRoom Create(DoubleRoom doubleRoom)
        {
            context.DoubleRooms.Add(doubleRoom);
            return doubleRoom;
        }

        //Remove a doubleroom from the context by it's id if it exists
        public DoubleRoom Delete(int Id)
        {
            var doubleRoom = Get(Id);
            if (doubleRoom != null)
            {
                context.DoubleRooms.Remove(doubleRoom);
            }

            return doubleRoom;
        }

        //Get a doubleroom from the context by it's id
        public DoubleRoom Get(int Id) => context.DoubleRooms.FirstOrDefault(d => d.Id == Id);

        //Get all doublerooms from the context as a list
        public IEnumerable<DoubleRoom> GetAll() => context.DoubleRooms.ToList();
    }
}