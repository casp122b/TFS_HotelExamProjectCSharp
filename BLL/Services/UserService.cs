using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class UserService : IService<UserBO>
    {
        UserConverter userConv = new UserConverter();
        DALFacade _facade;

        public UserService(DALFacade facade)
        {
            _facade = facade;
        }

        public UserBO Create(UserBO user)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.Create(userConv.Convert(user));
                uow.Complete();
                return userConv.Convert(newUser);
            }
        }

        public UserBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var removeUser = uow.UserRepository.Delete(Id);
                uow.Complete();
                return userConv.Convert(removeUser);
            }
        }

        public UserBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var getUser = uow.UserRepository.Get(Id);
                return userConv.Convert(getUser);
            }
        }

        public List<UserBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.UserRepository.GetAll().Select(userConv.Convert).ToList();
            }
        }

        public UserBO Update(UserBO user)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var updateUser = uow.UserRepository.Get(user.Id);
                if (updateUser == null)
                {
                    throw new InvalidOperationException("user not found");
                }
                updateUser.Username = user.Username;
                updateUser.Password = user.Password;
                uow.Complete();
                return userConv.Convert(updateUser);
            };
        }
    }
}
