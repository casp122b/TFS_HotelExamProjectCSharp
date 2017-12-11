using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class GuestService: IService<GuestBO>
    {
        GuestConverter guestConv = new GuestConverter();
        DALFacade facade;

        public GuestService(DALFacade facade)
        {
            this.facade = facade;
        }

        public GuestBO Create(GuestBO guest)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newGuest = uow.GuestRepository.Create(guestConv.Convert(guest));
                uow.Complete();
                return guestConv.Convert(newGuest);
            }
        }

        public GuestBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeGuest = uow.GuestRepository.Delete(Id);
                uow.Complete();
                return guestConv.Convert(removeGuest);
            }
        }

        public GuestBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getGuest = guestConv.Convert(uow.GuestRepository.Get(Id));
                return getGuest;
            }
        }

        public List<GuestBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.GuestRepository.GetAll().Select(guestConv.Convert).ToList();
            }
        }

        public GuestBO Update(GuestBO guest)
        {
            using (var uow = facade.UnitOfWork)
            {
                var updateGuest = uow.GuestRepository.Get(guest.Id);
                if (updateGuest == null)
                {
                    throw new InvalidOperationException("guest not found");
                }

                updateGuest.FirstName = guest.FirstName;
                updateGuest.LastName = guest.LastName;
                updateGuest.Address = guest.Address;
                uow.Complete();
                return guestConv.Convert(updateGuest);
            }
;
        }
    }
}