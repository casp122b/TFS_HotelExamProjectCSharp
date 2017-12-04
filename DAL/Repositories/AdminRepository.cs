using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class AdminRepository : IRepository<Admin>
    {
        HotelExamContext _context;
        public AdminRepository(HotelExamContext context)
        {
            _context = context;
        }

        public Admin Create(Admin admin)
        {
            _context.Admins.Add(admin);
            return admin;
        }

        public Admin Delete(int Id)
        {
            var admin = Get(Id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }
            return admin;
        }

        public Admin Get(int Id)
        {
            return _context.Admins.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins.ToList();
        }
    }
}
