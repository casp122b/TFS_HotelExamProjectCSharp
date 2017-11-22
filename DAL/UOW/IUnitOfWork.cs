using DAL.Entities;
using DAL.Repositories;
using System;

namespace DAL.UOW
{
    public interface IUnitOfWork :IDisposable
    {
        IGuestRepository GuestRepository { get; }
        IRepository<SingleRoom> SingleRoomRepository { get; }
        //IDoubleRepository DoubleRepository { get; }
        SuiteRepository SuiteRepository { get; }
        int Complete();
    }
}
