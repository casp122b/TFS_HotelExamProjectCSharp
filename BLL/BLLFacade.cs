using BLL.BusinessObjects;
using BLL.Services;
using DAL;
using Microsoft.Extensions.Configuration;
using System;

namespace BLL
{
    public class BLLFacade : IBLLFacade
    {
        //public BLLFacade(IConfiguration conf)
        //{
        //    facade = new DALFacade(new DbOptions()
        //    {
        //        ConnectionString = conf.GetConnectionString("SecretConnectionString"),
        //        Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
        //    });
        //}
        public IService<GuestBO> GuestService
        {
            get { return new GuestService(new DALFacade()); }
        }

        public IService<AdminBO> AdminService
        {
            get { return new AdminService(new DALFacade()); }
        }

        public IService<BookingBO> BookingService
        {
            get { return new BookingService(new DALFacade()); }
        }

        public IService<SingleRoomBO> SingleRoomService
        {
            get { return new SingleRoomService(new DALFacade()); }
        }

        public IService<DoubleRoomBO> DoubleRoomService
        {
            get { return new DoubleRoomService(new DALFacade()); }
        }

        public IService<SuiteBO> SuiteService
        {
            get { return new SuiteService(new DALFacade()); }
        }

        public IService<UserBO> UserService
        {
            get { return new UserService(new DALFacade()); }


        }
    }
}

