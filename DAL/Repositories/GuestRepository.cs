using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class GuestRepository: IRepository<Guest>
    {
        HotelExamContext context;

        //Makes the context avalible in the class
        public GuestRepository(HotelExamContext context)
        {
            this.context = context;
        }

        //Add a guest to the context
        public Guest Create(Guest guest)
        {
            context.Guests.Add(guest);
            return guest;
        }

        //Remove a guest from the context by it's id if it exists
        public Guest Delete(int Id)
        {
            var guest = Get(Id);
            if (guest != null)
            {
                context.Guests.Remove(guest);
            }

            return guest;
        }

        //Get a guest from the context by it's id
        public Guest Get(int Id) => context.Guests.FirstOrDefault(g => g.Id == Id);

        //Get all guests from the context as a list
        public IEnumerable<Guest> GetAll() => context.Guests.ToList();
    }
}