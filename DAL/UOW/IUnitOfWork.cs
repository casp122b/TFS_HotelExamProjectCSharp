using DAL.Entities;
using DAL.Repositories;
using System;

namespace DAL.UOW
{
    public interface IUnitOfWork :IDisposable
    {
        IGuestRepository GuestRepository { get; }
        IRepository<SingleRoom> SingleRepository { get; }
        IDoubleRepository DoubleRepository { get; }
        ISuiteRepository SuiteRepository { get; }
        int Complete();
    }
}
