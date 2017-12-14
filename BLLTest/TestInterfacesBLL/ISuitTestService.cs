using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;

namespace BLLTest.Mockdata
{
    public interface ISuitTestService
    {
        //C
        SuiteBO Create(SuiteBO s);
        //R
        List<SuiteBO> GetAll();
        SuiteBO GetById(int Id);
        //U
        SuiteBO Update(SuiteBO s);
        //D
        SuiteBO Delete(int Id);
    }
}
