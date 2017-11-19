using BLL.Services;
using DAL;

namespace BLL
{
    public class BLLFacade
    {
        public IRoomService RoomService
        {
            get { return new RoomService(new DALFacade()); }
        }
    }
}
