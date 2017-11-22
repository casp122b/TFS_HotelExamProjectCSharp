﻿using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class SingleRoomService : IService<SingleRoomBO>
    {
        SingleRoomConverter roomConv = new SingleRoomConverter();
        DALFacade _facade;

        public SingleRoomService(DALFacade facade)
        {
            _facade = facade;
        }

        public SingleRoomBO Create(SingleRoomBO singleRoom)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newSingleRoom = uow.SingleRoomRepository.Create(roomConv.Convert(singleRoom));
                uow.Complete();
                return roomConv.Convert(newSingleRoom);
            }
        }

        public SingleRoomBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var removeSingleRoom = uow.SingleRoomRepository.Delete(Id);
                uow.Complete();
                return roomConv.Convert(removeSingleRoom);
            }
        }

        public SingleRoomBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var getSingleRoom = uow.SingleRoomRepository.Get(Id);
                return roomConv.Convert(getSingleRoom);
            }
        }

        public List<SingleRoomBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.SingleRoomRepository.GetAll().Select(roomConv.Convert).ToList();
            }
        }

        public SingleRoomBO Update(SingleRoomBO singleRoomBO)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var updateSingleRoom = uow.SingleRoomRepository.Get(singleRoomBO.Id);
                if (updateSingleRoom == null)
                {
                    throw new InvalidOperationException("room not found");
                }
                updateSingleRoom.Price = singleRoomBO.Price;
                updateSingleRoom.Available = singleRoomBO.Available;
                uow.Complete();
                return roomConv.Convert(updateSingleRoom);
            };
        }
    }
}
