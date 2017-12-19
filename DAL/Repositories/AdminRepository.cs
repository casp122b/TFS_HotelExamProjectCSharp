using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class AdminRepository: IRepository<Admin>
    {
        HotelExamContext context;

        //Makes the context available in the class
        public AdminRepository(HotelExamContext context)
        {
            this.context = context;
        }

        //Add an admin to the context
        public Admin Create(Admin admin)
        {
            context.Admins.Add(admin);
            return admin;
        }

        //Remove an admin from the context by it's id if it exists
        public Admin Delete(int Id)
        {
            var admin = Get(Id);
            if (admin != null)
            {
                context.Admins.Remove(admin);
            }

            return admin;
        }

        //Get an admin from the context by it's id
        public Admin Get(int Id) => context.Admins.FirstOrDefault(a => a.Id == Id);

        //Get all admins from the context as a list
        public IEnumerable<Admin> GetAll()
        {
            if (context.Admins == null)
            {
                return null;
            }
            return context.Admins.ToList();
        }
    }
}