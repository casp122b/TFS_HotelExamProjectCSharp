using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository: IRepository<User>
    {
        HotelExamContext context;

        //Makes the context available in the class
        public UserRepository(HotelExamContext context)
        {
            this.context = context;
        }

        //Add a user to the context
        public User Create(User user)
        {
            context.Users.Add(user);
            return user;
        }

        //Remove a user from the context by it's id if it exists
        public User Delete(int Id)
        {
            var user = Get(Id);
            if (user != null)
            {
                context.Users.Remove(user);
            }

            return user;
        }

        //Get a user from the context by it's id
        public User Get(int Id) => context.Users.FirstOrDefault(u => u.Id == Id);

        //Get all users from the context as a list
        public IEnumerable<User> GetAll() => context.Users.ToList();
    }
}