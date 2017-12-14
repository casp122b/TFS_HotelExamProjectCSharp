using System;
using DAL.Entities;

namespace DAL
{
   public class UserValidation
    {

        User _user;

        public UserValidation(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("User cannot be null");
            }
            if (user.Username == null)
            {
                throw new ArgumentException("Username cannot be null");
            }
            _user = user;
        }


    }
}
