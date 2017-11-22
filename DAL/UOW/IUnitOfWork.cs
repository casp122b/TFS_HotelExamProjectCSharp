using DAL.Repositories;
using System;

namespace DAL.UOW
{
    public interface IUnitOfWork :IDisposable
    {
        IRoomRepository RoomRepository { get; }
        IGuestRepository GuestRepository { get; }
        int Complete();
    }
}
