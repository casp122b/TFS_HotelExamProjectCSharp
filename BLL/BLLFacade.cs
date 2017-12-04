using BLL.BusinessObjects;
using BLL.Services;
using DAL;
using Microsoft.Extensions.Configuration;
using System;

namespace BLL
{
    public class BLLFacade : IBLLFacade
    {
        private DALFacade facade;
        public BLLFacade(IConfiguration conf)
        {
            facade = new DALFacade(new DbOptions()
            {
                ConnectionString = conf.GetConnectionString("SecretConnectionString"),
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }
        public IService<GuestBO> GuestService
        {
            get { return new GuestService(facade); }
        }

        public IService<AdminBO> AdminService
        {
            get { return new AdminService(facade); }
        }

        public IService<BookingBO> BookingService
        {
            get { return new BookingService(facade); }
        }

        public IService<SingleRoomBO> SingleRoomService
        {
            get { return new SingleRoomService(facade); }
        }

        public IService<DoubleRoomBO> DoubleRoomService
        {
            get { return new DoubleRoomService(facade); }
        }

        public IService<SuiteBO> SuiteService
        {
            get { return new SuiteService(facade); }
        }

        public IService<UserBO> UserService
        {
            get { return new UserService(facade); }


        }
    }
}

