using DAL.Repositories;
using System;

namespace DAL.UOW
{
    public interface IUnitOfWork :IDisposable
    {
        IRoomRepository RoomRepository { get; }
        int Complete();
    }
}
