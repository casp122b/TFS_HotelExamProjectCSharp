using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLLTest.TestInterfacesBLL;

namespace BLLTest.MockdataBLL
{
    public class UserServiceTestMock : IUserTestService
    {
        List<UserBO> users = new List<UserBO>();

        public UserBO Create(UserBO u)
        {
            u.Id = users.Count + 1;
            users.Add(u);
            return u;
        }

        public List<UserBO> GetAll()
        {
            return users;
        }

        public UserBO GetById(int Id)
        {
            {
                foreach (UserBO u in users)
                {
                    if (u.Id == Id)
                    {
                        return u;
                    }
                }
                return null;
            }
        }

        public UserBO Update(UserBO u)
        {
            var x = Delete(u.Id);
            Create(u);
            return u;
        }

        public UserBO Delete(int Id)
        {
            var x = GetById(Id);
            users.Remove(x);
            return x;
        }
    }
}
