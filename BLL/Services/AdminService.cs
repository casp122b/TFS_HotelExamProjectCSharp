using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class AdminService: IService<AdminBO>
    {
        AdminConverter adminConv = new AdminConverter();
        DALFacade facade;

        //Makes the facade available in the class
        public AdminService(DALFacade facade)
        {
            this.facade = facade;
        }

        //Converts admin and goes through the facade to create and save it, then returns the admin converted back
        public AdminBO Create(AdminBO admin)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newAdmin = uow.AdminRepository.Create(adminConv.Convert(admin));
                uow.Complete();
                return adminConv.Convert(newAdmin);
            }
        }

        //Goes through the facade to delete admin by it's id and save the change, then returns the admin converted back, the id must already exsist
        public AdminBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeAdmin = uow.AdminRepository.Delete(Id);
                if (removeAdmin == null)
                {
                    throw new InvalidOperationException("admin not found");
                }

                uow.Complete();
                return adminConv.Convert(removeAdmin);
            }
        }

        //Goes through the facade to get an admin by it's id, and takes a user with it based on it's id, it returns a converted admin, the id must already exsist
        public AdminBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getAdmin = uow.AdminRepository.Get(Id);
                getAdmin.User = uow.UserRepository.Get(getAdmin.UserId);
                return adminConv.Convert(getAdmin);
            }
        }

        //Goes through the facade  to get a list of admins and return them converted
        public List<AdminBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.AdminRepository.GetAll().Select(adminConv.Convert).ToList();
            }
        }

        public AdminBO Update(AdminBO admin)
        {
            using (var uow = facade.UnitOfWork)
            {
                var updateAdmin = uow.AdminRepository.Get(admin.Id);
                if (updateAdmin == null)
                {
                    throw new InvalidOperationException("admin not found");
                }

                updateAdmin.FirstName = admin.FirstName;
                updateAdmin.LastName = admin.LastName;
                updateAdmin.Address = admin.Address;
                updateAdmin.UserId = admin.UserId;
                uow.Complete();
                return adminConv.Convert(updateAdmin);
            }
;
        }
    }
}