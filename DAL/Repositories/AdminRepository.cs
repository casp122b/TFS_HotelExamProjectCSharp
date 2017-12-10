using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class AdminRepository: IRepository<Admin>
    {
        HotelExamContext context;
        public AdminRepository(HotelExamContext context)
        {
            this.context = context;
        }

        public Admin Create(Admin admin)
        {
            context.Admins.Add(admin);
            return admin;
        }

        public Admin Delete(int Id)
        {
            var admin = Get(Id);
            if (admin != null)
            {
                context.Admins.Remove(admin);
            }

            return admin;
        }

        public Admin Get(int Id) => context.Admins.FirstOrDefault(a => a.Id == Id);

        public IEnumerable<Admin> GetAll() => context.Admins.ToList();
    }
}