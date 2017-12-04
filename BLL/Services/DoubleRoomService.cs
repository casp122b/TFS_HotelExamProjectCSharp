using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class DoubleRoomService : IService<DoubleRoomBO>
    {
        DoubleRoomConverter roomConv = new DoubleRoomConverter();
        DALFacade _facade;

        public DoubleRoomService(DALFacade facade)
        {
            _facade = facade;
        }

        public DoubleRoomBO Create(DoubleRoomBO doubleRoom)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newDoubleRoom = uow.DoubleRoomRepository.Create(roomConv.Convert(doubleRoom));
                uow.Complete();
                return roomConv.Convert(newDoubleRoom);
            }
        }

        public DoubleRoomBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var removeDoubleRoom = uow.DoubleRoomRepository.Delete(Id);
                uow.Complete();
                return roomConv.Convert(removeDoubleRoom);
            }
        }

        public DoubleRoomBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var getDoubleRoom = uow.DoubleRoomRepository.Get(Id);
                var getGuest = uow.GuestRepository.Get(Id);
                getDoubleRoom.Guest = uow.GuestRepository.Get(getDoubleRoom.GuestId);
                return roomConv.Convert(getDoubleRoom);
            }
        }

        public List<DoubleRoomBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.DoubleRoomRepository.GetAll().Select(roomConv.Convert).ToList();
            }
        }

        public DoubleRoomBO Update(DoubleRoomBO doubleRoomBO)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var updateDoubleRoom = uow.DoubleRoomRepository.Get(doubleRoomBO.Id);
                if (updateDoubleRoom == null)
                {
                    throw new InvalidOperationException("room not found");
                }
                updateDoubleRoom.Price = doubleRoomBO.Price;
                updateDoubleRoom.Available = doubleRoomBO.Available;
                updateDoubleRoom.GuestId = doubleRoomBO.GuestId;
                uow.Complete();
                return roomConv.Convert(updateDoubleRoom);
            };
        }
    }
}
