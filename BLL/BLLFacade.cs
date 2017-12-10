using BLL.BusinessObjects;
using BLL.Services;
using DAL;
using Microsoft.Extensions.Configuration;
using System;

namespace BLL
{
    public class BLLFacade: IBLLFacade
    {
        DALFacade facade;
        public BLLFacade(IConfiguration conf)
        {
            facade = new DALFacade(new DbOptions()
            {
                ConnectionString = conf.GetConnectionString("SecretConnectionString"),
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }
        public IService<GuestBO> GuestService => new GuestService(facade);

        public IService<AdminBO> AdminService => new AdminService(facade);

        public IService<BookingBO> BookingService => new BookingService(facade);

        public IService<SingleRoomBO> SingleRoomService => new SingleRoomService(facade);

        public IService<DoubleRoomBO> DoubleRoomService => new DoubleRoomService(facade);

        public IService<SuiteBO> SuiteService => new SuiteService(facade);

        public IService<UserBO> UserService => new UserService(facade);
    }
}