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

        public SingleRoomService SingleRoomService
        {
            get { return new SingleRoomService(new DALFacade()); }
        }

        public DoubleService DoubleService
        {
            get { return new DoubleService(new DALFacade()); }
        }

        public SuiteService SuiteService
        {
            get { return new SuiteService(new DALFacade()); }
        }
    }
}
