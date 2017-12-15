using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class DoubleRoomService: IService<DoubleRoomBO>
    {
        DoubleRoomConverter roomConv = new DoubleRoomConverter();
        DALFacade facade;

        public DoubleRoomService(DALFacade facade)
        {
            this.facade = facade;
        }

        public DoubleRoomBO Create(DoubleRoomBO doubleRoom)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newDoubleRoom = uow.DoubleRoomRepository.Create(roomConv.Convert(doubleRoom));
                uow.Complete();
                return roomConv.Convert(newDoubleRoom);
            }
        }

        public DoubleRoomBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeDoubleRoom = uow.DoubleRoomRepository.Delete(Id);
                uow.Complete();
                return roomConv.Convert(removeDoubleRoom);
            }
        }

        public DoubleRoomBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getDoubleRoom = uow.DoubleRoomRepository.Get(Id);
                return roomConv.Convert(getDoubleRoom);
            }
        }

        public List<DoubleRoomBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.DoubleRoomRepository.GetAll().Select(roomConv.Convert).ToList();
            }
        }

        public DoubleRoomBO Update(DoubleRoomBO doubleRoomBO)
        {
            using (var uow = facade.UnitOfWork)
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
            }
;
        }
    }
}