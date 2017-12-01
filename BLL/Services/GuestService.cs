using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System.Linq;

namespace BLL.Services
{
    public class GuestService : IService<GuestBO>
    {
        GuestConverter guestConv = new GuestConverter();
        BookingConverter bookConv = new BookingConverter();
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
                var getGuest = guestConv.Convert(uow.GuestRepository.Get(Id));
                getGuest.Bookings = uow.BookingRepository.GetAllById(getGuest.BookingIds)
                    .Select(b => bookConv.Convert(b))
                    .ToList();
                return getGuest;
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
                var guestUpdated = guestConv.Convert(guest);
       

                updateGuest.FirstName = guest.FirstName;
                updateGuest.LastName = guest.LastName;
                updateGuest.Address = guest.Address;

                guestUpdated.Bookings.RemoveAll(
                    b => !guestUpdated.Bookings.Exists(
                        g => g.GuestId == b.GuestId &&
                        g.Id == b.Id));

                updateGuest.Bookings.RemoveAll(
                    b => updateGuest.Bookings.Exists(
                        g => g.GuestId == b.GuestId &&
                        g.Id == b.Id));

                updateGuest.Bookings.AddRange(guestUpdated.Bookings);

                uow.Complete();
                return guestConv.Convert(updateGuest);
            };
        }
    }
}
