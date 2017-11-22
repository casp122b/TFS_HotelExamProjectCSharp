using BLL.Services;
using DAL;

namespace BLL
{
    public class BLLFacade
    {
        public IGuestService GuestService
        {
            get { return new GuestService(new DALFacade()); }
        }
    }
}
