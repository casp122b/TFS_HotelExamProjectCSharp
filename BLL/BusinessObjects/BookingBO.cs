using System;

namespace BLL.BusinessObjects
{
    public class BookingBO: IBusinessObject
    {
        public int Id
        {
            get; set;
        }
        public DateTime CheckIn
        {
            get; set;
        }
        public DateTime CheckOut
        {
            get; set;
        }
        public int SingleRoomId
        {
            get; set;
        }
        public int DoubleRoomId
        {
            get; set;
        }
        public int SuiteId
        {
            get; set;
        }
        public int UserId
        {
            get; set;
        }
        public SingleRoomBO SingleRoom
        {
            get; set;
        }
        public DoubleRoomBO DoubleRoom
        {
            get; set;
        }
        public SuiteBO Suite
        {
            get; set;
        }
        public UserBO User
        {
            get; set;
        }
    }
}