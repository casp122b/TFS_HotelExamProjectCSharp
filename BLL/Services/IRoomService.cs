using BLL.BusinessObjects;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IRoomService
    {
        List<RoomBO> GetAll();
        RoomBO Create(RoomBO roomBO);
        
    }
}
