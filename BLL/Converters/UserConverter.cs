using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class UserConverter: IConverter<User, UserBO>
    {
        GuestConverter guestConv;
        AdminConverter adminConv;

        public UserConverter()
        {
            guestConv = new GuestConverter();
            adminConv = new AdminConverter();
        }

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
                GuestId = userBO.GuestId,
                AdminId = userBO.AdminId
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
                Guest = guestConv.Convert(user.Guest),
                Admin = adminConv.Convert(user.Admin),
                GuestId = user.GuestId,
                AdminId = user.AdminId
            };
        }
    }
}