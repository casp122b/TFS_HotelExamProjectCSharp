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
        public string Role
        {
            get; set;
        }
        public int GuestId
        {
            get; set;
        }
        public GuestBO Guest
        {
            get; set;
        }
    }
}