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

<<<<<<< HEAD
        public SingleRoomService SingleRoomService
        {
            get { return new SingleRoomService(new DALFacade()); }
        }
=======
        //public SingleService SingleService
        //{
        //    get { return new SingleService(new DALFacade()); }
        //}
>>>>>>> master

        //public DoubleService DoubleService
        //{
        //    get { return new DoubleService(new DALFacade()); }
        //}

        public SuiteService SuiteService
        {
            get { return new SuiteService(new DALFacade()); }
        }
    }
}
