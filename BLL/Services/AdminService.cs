using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class AdminService : IService<AdminBO>
    {
        AdminConverter adminConv = new AdminConverter();
        DALFacade _facade;

        public AdminService(DALFacade facade)
        {
            _facade = facade;
        }

        public AdminBO Create(AdminBO admin)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newAdmin = uow.AdminRepository.Create(adminConv.Convert(admin));
                uow.Complete();
                return adminConv.Convert(newAdmin);
            }
        }

        public AdminBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var removeAdmin = uow.AdminRepository.Delete(Id);
                uow.Complete();
                return adminConv.Convert(removeAdmin);
            }
        }

        public AdminBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var getAdmin = uow.AdminRepository.Get(Id);
                return adminConv.Convert(getAdmin);
            }
        }

        public List<AdminBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.AdminRepository.GetAll().Select(adminConv.Convert).ToList();
            }
        }

        public AdminBO Update(AdminBO admin)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var updateAdmin = uow.AdminRepository.Get(admin.Id);
                if (updateAdmin == null)
                {
                    throw new InvalidOperationException("admin not found");
                }
                updateAdmin.FirstName = admin.FirstName;
                updateAdmin.LastName = admin.LastName;
                updateAdmin.Address = admin.Address;
                updateAdmin.UserName = admin.UserName;
                updateAdmin.Password = admin.Password;
                uow.Complete();
                return adminConv.Convert(updateAdmin);
            };
        }
    }
}
