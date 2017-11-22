using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class SingleRoomConverter : IConverter<SingleRoom, SingleRoomBO>
    {
        public SingleRoom Convert(SingleRoomBO single)
        {
            if (single == null) { return null; }
            return new SingleRoom()
            {
                Id = single.Id,
                Price = single.Price,
                Available = single.Available
            };
        }

        public SingleRoomBO Convert(SingleRoom single)
        {
            if (single == null) { return null; }
            return new SingleRoomBO()
            {
                Id = single.Id,
                Price = single.Price,
                Available = single.Available
            };
        }
    }
}
