
namespace BLL.BusinessObjects
{
    public class UserBO: IBusinessObject
    {
        public int Id
        {
            get; set;
        }
        public string Username
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public byte[] PasswordHash
        {
            get; set;
        }
        public byte[] PasswordSalt
        {
            get; set;
        }
        public string Role
        {
            get; set;
        }
    }
}