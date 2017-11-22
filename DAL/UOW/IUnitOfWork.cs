using DAL.Entities;
using DAL.Repositories;
using System;

namespace DAL.UOW
{
    public interface IUnitOfWork :IDisposable
    {
        IGuestRepository GuestRepository { get; }
<<<<<<< HEAD
        IRepository<SingleRoom> SingleRepository { get; }
        IDoubleRepository DoubleRepository { get; }
        ISuiteRepository SuiteRepository { get; }
=======
        //ISingleRepository SingleRepository { get; }
        //IDoubleRepository DoubleRepository { get; }
>>>>>>> master
        int Complete();
    }
}
