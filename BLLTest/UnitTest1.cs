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
    public class BLLTests
    {
        [Fact]
        public void CRUDTestSuites()
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
        [Fact]
        public void CRUDTestUsers()
        {
            IUserTestService _service = new UserTestMock();
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
