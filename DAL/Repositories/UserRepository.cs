using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        HotelExamContext _context;
        public UserRepository(HotelExamContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public User Delete(int Id)
        {
            var user = Get(Id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return user;
        }

        public User Get(int Id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
