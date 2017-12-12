namespace BLL.BusinessObjects
{
    public class SingleRoomBO: IBusinessObject
    {
        public int Id
        {
            get; set;
        }
        public double Price
        {
            get; set;
        }
        public int Available
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