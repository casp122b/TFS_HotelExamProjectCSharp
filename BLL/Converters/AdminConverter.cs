﻿using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class AdminConverter: IConverter<Admin, AdminBO>
    {
        public Admin Convert(AdminBO admin)
        {
            if (admin == null)
            {
                return null;
            }

            return new Admin()
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.Address
            };
        }

        public AdminBO Convert(Admin admin)
        {
            if (admin == null)
            {
                return null;
            }

            return new AdminBO()
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.Address
            };
        }
    }
}