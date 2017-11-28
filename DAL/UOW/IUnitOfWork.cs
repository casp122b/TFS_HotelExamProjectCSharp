using DAL.Entities;
using DAL.Repositories;
using System;

namespace DAL.UOW
{
    public interface IUnitOfWork :IDisposable
    {
        GuestRepository GuestRepository { get; }
        SingleRoomRepository SingleRoomRepository { get; }
        DoubleRoomRepository DoubleRoomRepository { get; }
        SuiteRepository SuiteRepository { get; }
        int Complete();
    }
}
