using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class GuestConverter : IConverter<Guest, GuestBO>
    {
        public Guest Convert(GuestBO guest)
        {
            if (guest == null) { return null; }
            return new Guest()
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Address = guest.Address,
                UserName = guest.UserName,
                Password = guest.Password
            };
        }

        public GuestBO Convert(Guest guest)
        {
            if (guest == null) { return null; }
            return new GuestBO()
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Address = guest.Address,
                UserName = guest.UserName,
                Password = guest.Password
            };
        }
    }
}
