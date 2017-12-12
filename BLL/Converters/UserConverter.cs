using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class UserConverter: IConverter<User, UserBO>
    {
        public User Convert(UserBO userBO)
        {
            if (userBO == null)
            {
                return null;
            }

            return new User()
            {
                Id = userBO.Id,
                Username = userBO.Username,
                Password = userBO.Password,
                Role = userBO.Role,
                GuestId = userBO.GuestId
            };
        }

        public UserBO Convert(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserBO()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Role = user.Role,
                Guest = new GuestConverter().Convert(user.Guest),
                GuestId = user.GuestId
            };
        }
    }
}