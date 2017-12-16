namespace BLL.BusinessObjects
{
    public class GuestBO
    {
        public int? Id
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
        public int UserId
        {
            get; set;
        }
        public UserBO User
        {
            get; set;
        }
    }
}