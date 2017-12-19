using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class DoubleRoomConverter: IConverter<DoubleRoom, DoubleRoomBO>
    {
        // Converts doubleroomBO to doubleroom
        public DoubleRoom Convert(DoubleRoomBO doubleRoomBO)
        {
            if (doubleRoomBO == null)
            {
                return null;
            }

            return new DoubleRoom()
            {
                Id = doubleRoomBO.Id,
                Name = doubleRoomBO.Name,
                Price = doubleRoomBO.Price,
                Available = doubleRoomBO.Available,
                GuestId = doubleRoomBO.GuestId
            };
        }

        // Converts doubleroom to doubleroomBO
        public DoubleRoomBO Convert(DoubleRoom doubleRoom)
        {
            if (doubleRoom == null)
            {
                return null;
            }

            return new DoubleRoomBO()
            {
                Id = doubleRoom.Id,
                Name = doubleRoom.Name,
                Price = doubleRoom.Price,
                Available = doubleRoom.Available,
                Guest = new GuestConverter().Convert(doubleRoom.Guest),
                GuestId = doubleRoom.GuestId
            };
        }
    }
}