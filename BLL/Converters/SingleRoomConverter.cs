using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class SingleRoomConverter: IConverter<SingleRoom, SingleRoomBO>
    {
        public SingleRoom Convert(SingleRoomBO singleRoomBO)
        {
            if (singleRoomBO == null)
            {
                return null;
            }

            return new SingleRoom()
            {
                Id = singleRoomBO.Id,
                Price = singleRoomBO.Price,
                Available = singleRoomBO.Available,
                UserId = singleRoomBO.UserId
            };
        }

        public SingleRoomBO Convert(SingleRoom singleRoom)
        {
            if (singleRoom == null)
            {
                return null;
            }

            return new SingleRoomBO()
            {
                Id = singleRoom.Id,
                Price = singleRoom.Price,
                Available = singleRoom.Available,
                User = new UserConverter().Convert(singleRoom.User),
                UserId = singleRoom.UserId
            };
        }
    }
}