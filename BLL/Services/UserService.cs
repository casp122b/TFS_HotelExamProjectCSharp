using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService: IService<UserBO>
    {
        UserConverter userConv = new UserConverter();
        DALFacade facade;

        //Makes the facade available in the class
        public UserService(DALFacade facade)
        {
            this.facade = facade;
        }

        //Converts user and goes through the facade to create and save it, then returns the user converted back
        public UserBO Create(UserBO user)
        {
            string password;
            byte[] passwordHash, passwordSalt;

            using (var uow = facade.UnitOfWork)
            {
                password = user.Password;
                var newUser = uow.UserRepository.Create(userConv.Convert(user));
                //creates hash and salt corresponding to the entered password for the user
                CreatePasswordHash(password, out passwordHash, out passwordSalt);
                newUser.PasswordHash = passwordHash;
                newUser.PasswordSalt = passwordSalt;
                newUser.Role = user.Role;
                uow.Complete();
                return userConv.Convert(newUser);
            }
        }

        //Goes through the facade to delete user by it's id and save the change, then returns the user converted back, the id must already exsist
        public UserBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeUser = uow.UserRepository.Delete(Id);
                if (removeUser == null)
                {
                    throw new InvalidOperationException("user not found");
                }

                uow.Complete();
                return userConv.Convert(removeUser);
            }
        }

        //Goes through the facade to get a user by it's id, it returns a converted user, the id must already exsist
        public UserBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getUser = uow.UserRepository.Get(Id);
                return userConv.Convert(getUser);
            }
        }

        //Goes through the facade  to get a list of users and return them converted
        public List<UserBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
                return uow.UserRepository.GetAll().Select(userConv.Convert).ToList();

        }

        //Goes through the facade to get user by it's id and changes it's values, it returns a converted user, the id must already exsist
        public UserBO Update(UserBO user)
        {
            byte[] passwordHash, passwordSalt;

            using (var uow = facade.UnitOfWork)
            {
                var updateUser = uow.UserRepository.Get(user.Id);
                if (updateUser == null)
                {
                    throw new InvalidOperationException("user not found");
                }

                updateUser.Username = user.Username;
                updateUser.Password = user.Password;
                CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
                updateUser.PasswordHash = passwordHash;
                updateUser.PasswordSalt = passwordSalt;
                updateUser.Role = user.Role;
                uow.Complete();
                return userConv.Convert(updateUser);
            }
;
        }

        //takes in a password and outputs hash/salt
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //checks if password is null
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            //creates a key (salt) and a hash value matching the password entered. The used algorithm is the 512 bit version of SHA
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}