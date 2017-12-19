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

        // Makes the facade available in the class
        public DoubleRoomService(DALFacade facade)
        {
            this.facade = facade;
        }

        // Converts doubleroom and goes through the facade to create and save it, then returns the doubleroom converted back
        public DoubleRoomBO Create(DoubleRoomBO doubleRoom)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newDoubleRoom = uow.DoubleRoomRepository.Create(roomConv.Convert(doubleRoom));
                uow.Complete();
                return roomConv.Convert(newDoubleRoom);
            }
        }

        // Goes through the facade to delete doubleroom by it's id and save the change, then returns the doubleroom converted back, the id must already exsist
        public DoubleRoomBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeDoubleRoom = uow.DoubleRoomRepository.Delete(Id);
                if (removeDoubleRoom == null)
                {
                    throw new InvalidOperationException("room not found");
                }

                uow.Complete();
                return roomConv.Convert(removeDoubleRoom);
            }
        }

        // Goes through the facade to get a doubleroom by it's id, it returns a converted doubleroom, the id must already exsist
        public DoubleRoomBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getDoubleRoom = uow.DoubleRoomRepository.Get(Id);
                return roomConv.Convert(getDoubleRoom);
            }
        }

        // Goes through the facade  to get a list of doublerooms and return them converted
        public List<DoubleRoomBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.DoubleRoomRepository.GetAll().Select(roomConv.Convert).ToList();
            }
        }

        // Goes through the facade to get doubleroom by it's id and changes it's values, it returns a converted doubleroom, the id must already exsist
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
                updateDoubleRoom.Name = doubleRoomBO.Name;
                updateDoubleRoom.GuestId = doubleRoomBO.GuestId;
                uow.Complete();
                return roomConv.Convert(updateDoubleRoom);
            }

;
        }
    }
}