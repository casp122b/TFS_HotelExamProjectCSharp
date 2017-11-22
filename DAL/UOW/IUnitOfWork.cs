using DAL.Repositories;
using System;

namespace DAL.UOW
{
    public interface IUnitOfWork :IDisposable
    {
        IGuestRepository GuestRepository { get; }
        //ISingleRepository SingleRepository { get; }
        //IDoubleRepository DoubleRepository { get; }
        SuiteRepository SuiteRepository { get; }
        int Complete();
    }
}
