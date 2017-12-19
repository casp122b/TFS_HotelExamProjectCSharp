using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class UserConverter: IConverter<User, UserBO>
    {
        // Converts userBO to user
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
                PasswordHash = userBO.PasswordHash,
                PasswordSalt = userBO.PasswordSalt,
                Role = userBO.Role
            };
        }

        // Converts user to userBO
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
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                Role = user.Role
            };
        }
    }
}