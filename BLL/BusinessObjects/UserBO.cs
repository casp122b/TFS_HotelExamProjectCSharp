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
        public string Firstname
        {
            get; set;
        }
        public string Lastname
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
    }
}