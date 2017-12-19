using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class SingleRoomConverter: IConverter<SingleRoom, SingleRoomBO>
    {
        // Converts singleroomBO to singleroom
        public SingleRoom Convert(SingleRoomBO singleRoomBO)
        {
            if (singleRoomBO == null)
            {
                return null;
            }

            return new SingleRoom()
            {
                Id = singleRoomBO.Id,
                Name = singleRoomBO.Name,
                Price = singleRoomBO.Price,
                Available = singleRoomBO.Available,
                GuestId = singleRoomBO.GuestId
            };
        }

        // Converts singleroom to singleroomBO
        public SingleRoomBO Convert(SingleRoom singleRoom)
        {
            if (singleRoom == null)
            {
                return null;
            }

            return new SingleRoomBO()
            {
                Id = singleRoom.Id,
                Name = singleRoom.Name,
                Price = singleRoom.Price,
                Available = singleRoom.Available,
                Guest = new GuestConverter().Convert(singleRoom.Guest),
                GuestId = singleRoom.GuestId
            };
        }
    }
}