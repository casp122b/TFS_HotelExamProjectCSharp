using BLL.Services;
using DAL;

namespace BLL
{
    public class BLLFacade
    {
        public RoomService RoomService
        {
            get { return new RoomService(new DALFacade()); }
        }

        public IGuestService GuestService
        {
            get { return new GuestService(new DALFacade()); }
        }
    }
}
