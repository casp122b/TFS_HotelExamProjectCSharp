using BLL.Services;
using DAL;

namespace BLL
{
    public class BLLFacade
    {
        public GuestService GuestService
        {
            get { return new GuestService(new DALFacade()); }
        }

        public AdminService AdminService
        {
            get { return new AdminService(new DALFacade()); }
        }

        public BookingService BookingService
        {
            get { return new BookingService(new DALFacade()); }
        }

        public SingleRoomService SingleRoomService
        {
            get { return new SingleRoomService(new DALFacade()); }
        }

        public DoubleRoomService DoubleRoomService
        {
            get { return new DoubleRoomService(new DALFacade()); }
        }

        public SuiteService SuiteService
        {
            get { return new SuiteService(new DALFacade()); }
        }
    }
}
