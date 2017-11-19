using BLL.BusinessObjects;
using DAL.Entities;
using System;

namespace BLL.Converters
{
    public class RoomConverter
    {
        internal RoomBO Convert(Room room)
        {
            RoomBO newRoomBO = new RoomBO()
            {
                Id = room.Id,
                Price = room.Price,
                Available = room.Available
            };
            if (room == null)
            {
                return null;
            }
            else if (room != null)
            {
                Console.WriteLine("Converter (Entity)" + " " + newRoomBO);
            };
            return newRoomBO;
        }

        internal Room Convert(RoomBO roomBO)
        {
            Room newRoom = new Room()
            {
                Id = roomBO.Id,
                Price = roomBO.Price,
                Available = roomBO.Available
            };
            if (roomBO == null) { return null; }
            else if (roomBO != null)
            {
                Console.WriteLine("Converter (BO)" + " " + newRoom);
            };
            return newRoom;
        }
    }
}
