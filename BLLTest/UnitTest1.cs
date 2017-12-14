using System;
using Xunit;
using Moq;
using BLL;
using BLL.BusinessObjects;
using BLLTest.Mockdata;

namespace BLLTest
{
    public class UnitTest1
    {
        [Fact]
        public void CRUDTestxUnit()
        {
            ISuitTestService _service = new SuiteTestMock();
            var SuiteTest = _service.Create(new SuiteBO
            {
               Available = 1
            });

            int id = SuiteTest.Id;
            Assert.NotNull(SuiteTest);
            Assert.Equal(SuiteTest.Available, 1);
            Assert.Equal(_service.GetById(id).Available, 1);

            SuiteTest.Available = 2;
            _service.Update(SuiteTest);
            Assert.Equal(SuiteTest.Available, 2);

            _service.Delete(SuiteTest.Id);


            Assert.Null(_service.GetById(SuiteTest.Id));

        }
    }
}
