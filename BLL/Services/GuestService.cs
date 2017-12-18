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

        //Makes the facade available in the class
        public GuestService(DALFacade facade)
        {
            this.facade = facade;
        }

        //Converts guest and goes through the facade to create and save it, then returns the guest converted back
        public GuestBO Create(GuestBO guest)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newGuest = uow.GuestRepository.Create(guestConv.Convert(guest));
                uow.Complete();
                return guestConv.Convert(newGuest);
            }
        }

        //Goes through the facade to delete guest by it's id and save the change, then returns the guest converted back, the id must already exsist
        public GuestBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeGuest = uow.GuestRepository.Delete(Id);
                if (removeGuest == null)
                {
                    throw new InvalidOperationException("guest not found");
                }

                uow.Complete();
                return guestConv.Convert(removeGuest);
            }
        }

        //Goes through the facade to get an guest by it's id, and takes a user with it based on it's id, it returns a converted guest, the id must already exsist
        public GuestBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getGuest = uow.GuestRepository.Get(Id);
                getGuest.User = uow.UserRepository.Get(getGuest.UserId);
                return guestConv.Convert(getGuest);
            }
        }

        //Goes through the facade  to get a list of guests and return them converted
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
                updateGuest.UserId = guest.UserId;
                uow.Complete();
                return guestConv.Convert(updateGuest);
            }
;
        }
    }
}