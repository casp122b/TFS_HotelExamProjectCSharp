using System.Collections.Generic;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System.Linq;

namespace BLL.Services
{
    public class RoomService : IRoomService
    {
        RoomConverter roomCon = new RoomConverter();
        DALFacade _facade;

        public RoomService(DALFacade facade)
        {
            _facade = facade;
        }

        public List<RoomBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.RoomRepository.GetAll().Select(r => roomCon.Convert(r)).ToList();
            }
        }

        public RoomBO Create(RoomBO roomBO)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newRoom = uow.RoomRepository.Create(roomCon.Convert(roomBO));
                uow.Complete();
                return roomCon.Convert(newRoom);
            };
        }
    }
}
