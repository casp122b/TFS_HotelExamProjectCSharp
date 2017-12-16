using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class GuestRepository: IGuestRepository<Guest>
    {
        HotelExamContext context;
        public GuestRepository(HotelExamContext context)
        {
            this.context = context;
        }

        public Guest Create(Guest guest)
        {
            context.Guests.Add(guest);
            return guest;
        }

        public Guest Delete(int Id)
        {
            var guest = Get(Id);
            if (guest != null)
            {
                context.Guests.Remove(guest);
            }

            return guest;
        }

        public Guest Get(int? Id) => context.Guests.FirstOrDefault(g => g.Id == Id);

        public IEnumerable<Guest> GetAll() => context.Guests.ToList();
    }
}