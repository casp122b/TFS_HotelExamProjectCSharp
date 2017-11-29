using DAL.Entities;
using DAL.Repositories;
using System;

namespace DAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        GuestRepository GuestRepository { get; }
        AdminRepository AdminRepository { get; }
        UserRepository UserRepository { get; }
        BookingRepository BookingRepository { get; }
        SingleRoomRepository SingleRoomRepository { get; }
        DoubleRoomRepository DoubleRoomRepository { get; }
        SuiteRepository SuiteRepository { get; }
        int Complete();
    }
}
