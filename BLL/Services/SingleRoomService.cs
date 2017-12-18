using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class SingleRoomService: IService<SingleRoomBO>
    {
        SingleRoomConverter roomConv = new SingleRoomConverter();
        DALFacade facade;

        //Makes the facade available in the class
        public SingleRoomService(DALFacade facade)
        {
            this.facade = facade;
        }
        //Converts singleroom and goes through the facade to create and save it, then returns the singleroom converted back
        public SingleRoomBO Create(SingleRoomBO singleRoom)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newSingleRoom = uow.SingleRoomRepository.Create(roomConv.Convert(singleRoom));
                uow.Complete();
                return roomConv.Convert(newSingleRoom);
            }
        }

        //Goes through the facade to delete singleroom by it's id and save the change, then returns the singleroom converted back, the id must already exsist
        public SingleRoomBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeSingleRoom = uow.SingleRoomRepository.Delete(Id);
                if (removeSingleRoom == null)
                {
                    throw new InvalidOperationException("room not found");
                }

                uow.Complete();
                return roomConv.Convert(removeSingleRoom);
            }
        }

        //Goes through the facade to get a singleroom by it's id, it returns a converted singleroom, the id must already exsist
        public SingleRoomBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getSingleRoom = uow.SingleRoomRepository.Get(Id);
                return roomConv.Convert(getSingleRoom);
            }
        }

        //Goes through the facade  to get a list of singlerooms and return them converted
        public List<SingleRoomBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.SingleRoomRepository.GetAll().Select(roomConv.Convert).ToList();
            }
        }

        public SingleRoomBO Update(SingleRoomBO singleRoomBO)
        {
            using (var uow = facade.UnitOfWork)
            {
                var updateSingleRoom = uow.SingleRoomRepository.Get(singleRoomBO.Id);
                if (updateSingleRoom == null)
                {
                    throw new InvalidOperationException("room not found");
                }

                updateSingleRoom.Price = singleRoomBO.Price;
                updateSingleRoom.Available = singleRoomBO.Available;
                updateSingleRoom.Name = singleRoomBO.Name;
                updateSingleRoom.GuestId = singleRoomBO.GuestId;
                uow.Complete();
                return roomConv.Convert(updateSingleRoom);
            }
;
        }
    }
}