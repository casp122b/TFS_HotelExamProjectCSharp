using DAL.Entities;
using DAL.Repositories;
using System;

namespace DAL.UOW
{
    public interface IUnitOfWork: IDisposable
    {
        IGuestRepository<Guest> GuestRepository
        {
            get;
        }
        IRepository<Admin> AdminRepository
        {
            get;
        }
        IRepository<User> UserRepository
        {
            get;
        }
        IRepository<Booking> BookingRepository
        {
            get;
        }
        IRepository<SingleRoom> SingleRoomRepository
        {
            get;
        }
        IRepository<DoubleRoom> DoubleRoomRepository
        {
            get;
        }
        IRepository<Suite> SuiteRepository
        {
            get;
        }
        int Complete();
    }
}