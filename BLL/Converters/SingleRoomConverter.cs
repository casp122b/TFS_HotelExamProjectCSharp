using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class SingleRoomConverter : IConverter<SingleRoom, SingleRoomBO>
    {
        public SingleRoom Convert(SingleRoomBO singleRoomBO)
        {
            if (singleRoomBO == null) { return null; }
            return new SingleRoom()
            {
                Id = singleRoomBO.Id,
                Price = singleRoomBO.Price,
                Available = singleRoomBO.Available
            };
        }

        public SingleRoomBO Convert(SingleRoom singleRoom)
        {
            if (singleRoom == null) { return null; }
            return new SingleRoomBO()
            {
                Id = singleRoom.Id,
                Price = singleRoom.Price,
                Available = singleRoom.Available
            };
        }
    }
}
