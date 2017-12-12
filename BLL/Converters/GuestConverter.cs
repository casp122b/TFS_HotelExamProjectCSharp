using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class GuestConverter: IConverter<Guest, GuestBO>
    {
        public Guest Convert(GuestBO guestBO)
        {
            if (guestBO == null)
            {
                return null;
            }

            return new Guest()
            {
                Id = guestBO.Id,
                FirstName = guestBO.FirstName,
                LastName = guestBO.LastName,
                Address = guestBO.Address,
                UserId = guestBO.UserId
            };
        }

        public GuestBO Convert(Guest guest)
        {
            if (guest == null)
            {
                return null;
            }

            return new GuestBO()
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Address = guest.Address,
                User = new UserConverter().Convert(guest.User),
                UserId = guest.UserId
            };
        }
    }
}