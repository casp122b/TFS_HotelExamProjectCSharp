using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class RoomConverter
    {
        internal RoomBO Convert(Room room)
        {
            if(room == null)
            {
                return null;
            }
            return new RoomBO()
            {
                Id = room.Id,
                Price = room.Price,
                Available = room.Available
            };
        }

        internal Room Convert(RoomBO roomBO)
        {
            if (roomBO == null) { return null; }
            return new Room()
            {
                Id = roomBO.Id,
                Price = roomBO.Price,
                Available = roomBO.Available
            };
        }
    }
}
