using System.Collections.Generic;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System.Linq;
using System;

namespace BLL.Services
{
    public class RoomService
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
                Console.WriteLine("Service" + " " + newRoom);
                return roomCon.Convert(newRoom);
            };
        }

        public RoomBO Update(RoomBO roomBO)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var updateRoom = uow.RoomRepository.Update(roomCon.Convert(roomBO));
                uow.Complete();
                Console.WriteLine("Service" + " " + updateRoom);
                return roomCon.Convert(updateRoom);
            };
        }
    }
}
