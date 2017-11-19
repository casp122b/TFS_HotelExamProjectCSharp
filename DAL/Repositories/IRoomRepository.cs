using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IRoomRepository
    {
        List<Room> GetAll();
        Room Create(Room room);
        Room Update(Room room);
    }
}
