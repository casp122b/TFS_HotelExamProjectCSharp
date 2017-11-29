using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class UserConverter : IConverter<User, UserBO>
    {
        public User Convert(UserBO user)
        {
            if (user == null) { return null; }
            return new User()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
        }

        public UserBO Convert(User user)
        {
            if (user == null) { return null; }
            return new UserBO()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}
