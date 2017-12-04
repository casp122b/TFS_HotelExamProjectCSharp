using BLL.BusinessObjects;
using BLL.Services;

namespace BLL
{
    public interface IBLLFacade
    {
        IService<AdminBO> AdminService { get; }
        IService<BookingBO> BookingService { get; }
        IService<DoubleRoomBO> DoubleRoomService { get; }
        IService<GuestBO> GuestService { get; }
        IService<SingleRoomBO> SingleRoomService { get; }
        IService<SuiteBO> SuiteService { get; }
        IService<UserBO> UserService { get; }
    }
}