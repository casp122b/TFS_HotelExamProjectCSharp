using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;

namespace BLLTest.TestInterfacesBLL
{
    interface IUserTestService
    {
        //C
        UserBO Create(UserBO u);
        //R
        List<UserBO> GetAll();
        UserBO GetById(int Id);
        //U
        UserBO Update(UserBO u);
        //D
        UserBO Delete(int Id);
    }
}
