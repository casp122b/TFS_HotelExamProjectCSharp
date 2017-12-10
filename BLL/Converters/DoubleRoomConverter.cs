using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class DoubleRoomConverter: IConverter<DoubleRoom, DoubleRoomBO>
    {
        public DoubleRoom Convert(DoubleRoomBO doubleRoomBO)
        {
            if (doubleRoomBO == null)
            {
                return null;
            }

            return new DoubleRoom()
            {
                Id = doubleRoomBO.Id,
                Price = doubleRoomBO.Price,
                Available = doubleRoomBO.Available,
                GuestId = doubleRoomBO.GuestId
            };
        }

        public DoubleRoomBO Convert(DoubleRoom doubleRoom)
        {
            if (doubleRoom == null)
            {
                return null;
            }

            return new DoubleRoomBO()
            {
                Id = doubleRoom.Id,
                Price = doubleRoom.Price,
                Available = doubleRoom.Available,
                Guest = new GuestConverter().Convert(doubleRoom.Guest),
                GuestId = doubleRoom.GuestId
            };
        }
    }
}