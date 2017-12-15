using System;
using Xunit;
using Moq;
using BLL;
using BLL.BusinessObjects;
using BLLTest.Mockdata;
using BLLTest.MockdataBLL;
using BLLTest.TestInterfacesBLL;

namespace BLLTest
{
    public class BllTests
    {
        [Fact]
        public void CRUDTestSuites()
        {
            ISuitTestService _service = new SuiteServiceTestMock();
            var SuiteTest = _service.Create(new SuiteBO
            {
               Available = true
            });

            int id = SuiteTest.Id;
            Assert.NotNull(SuiteTest);
            Assert.Equal(SuiteTest.Available, true);
            Assert.Equal(_service.GetById(id).Available, true);

            SuiteTest.Available = false;
            _service.Update(SuiteTest);
            Assert.Equal(SuiteTest.Available, false);

            _service.Delete(SuiteTest.Id);


            Assert.Null(_service.GetById(SuiteTest.Id));

        }
        [Fact]
        public void CRUDTestUsers()
        {
            IUserTestService _service = new UserServiceTestMock();
            var UserTest = _service.Create(new UserBO 
            {
               Username = "skipperBent1",
                Password = "Bente1"
            });

            int id = UserTest.Id;
            Assert.NotNull(UserTest);
            Assert.Equal(UserTest.Username, "skipperBent1");
            Assert.Equal(UserTest.Password, "Bente1");
            Assert.Equal(_service.GetById(id).Username , "skipperBent1");
            Assert.Equal(_service.GetById(id).Password, "Bente1");
            UserTest.Username = "lars";
            UserTest.Password = "bent";
            _service.Update(UserTest);
            Assert.Equal(UserTest.Password, "bent");

            _service.Delete(UserTest.Id);


            Assert.Null(_service.GetById(UserTest.Id));

        }
    }
}
