namespace BLL.BusinessObjects
{
    public class SingleRoomBO: IBusinessObject
    {
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public double Price
        {
            get; set;
        }
        public bool Available
        {
            get; set;
        }
        public int? GuestId
        {
            get; set;
        }
        public GuestBO Guest
        {
            get; set;
        }
    }
}