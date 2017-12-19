using BLL.BusinessObjects;
using System.Collections.Generic;

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
