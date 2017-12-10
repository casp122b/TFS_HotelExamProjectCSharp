using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository: IRepository<User>
    {
        HotelExamContext context;
        public UserRepository(HotelExamContext context)
        {
            this.context = context;
        }

        public User Create(User user)
        {
            context.Users.Add(user);
            return user;
        }

        public User Delete(int Id)
        {
            var user = Get(Id);
            if (user != null)
            {
                context.Users.Remove(user);
            }

            return user;
        }

        public User Get(int Id) => context.Users.FirstOrDefault(u => u.Id == Id);

        public IEnumerable<User> GetAll() => context.Users.ToList();
    }
}