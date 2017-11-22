using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System.Linq;

namespace BLL.Services
{
    public class GuestService : IGuestService
    {
        GuestConverter guestConv = new GuestConverter();
        DALFacade _facade;

        public GuestService(DALFacade facade)
        {
            _facade = facade;
        }

        public GuestBO Create(GuestBO guest)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newGuest = uow.GuestRepository.Create(guestConv.Convert(guest));
                uow.Complete();
                return guestConv.Convert(newGuest);
            }
        }

        public GuestBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var removeGuest = uow.GuestRepository.Delete(Id);
                uow.Complete();
                return guestConv.Convert(removeGuest);
            }
        }

        public GuestBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var getGuest = uow.GuestRepository.Get(Id);
                return guestConv.Convert(getGuest);
            }
        }

        public List<GuestBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GuestRepository.GetAll().Select(guestConv.Convert).ToList();
            }
        }

        public GuestBO Update(GuestBO guest)
        {
            using (var uow = _facade.UnitOfWork)
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
            };
        }
    }
}
