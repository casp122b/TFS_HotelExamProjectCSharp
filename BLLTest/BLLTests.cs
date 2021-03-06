using BLL.BusinessObjects;
using BLLTest.Mockdata;
using BLLTest.MockdataBLL;
using BLLTest.TestInterfacesBLL;
using Xunit;

namespace BLLTest
{
    public class BllTests
    {
        [Fact]
        //first we create a new suite and set all the properties a suiteBO has except Guest, we then check if the properties have been created, then we update the propeties and give them new values and check if they have been updated, after that we then delete the suiteBO and end the test checking if the suiteBO has been deleted or if it still exist
        public void CRUDTestSuites()
        {
            ISuitTestService service = new SuiteServiceTestMock();
            var suiteTest = service.Create(new SuiteBO
            {
                Name = "Hytten",
                Price = 1500,
                GuestId = 2,
                Available = true


            });

            var id = suiteTest.Id;
            Assert.NotNull(suiteTest);
            Assert.Equal(suiteTest.Available, true);
            Assert.Equal(suiteTest.GuestId, 2);
            Assert.Equal(suiteTest.Name, "Hytten");
            Assert.Equal(suiteTest.Price, 1500);
            Assert.Equal(service.GetById(id).Available, true);
            Assert.Equal(service.GetById(id).Name, "Hytten");
            Assert.Equal(service.GetById(id).Price, 1500);
            Assert.Equal(service.GetById(id).GuestId, 2);
            suiteTest.Available = false;
            suiteTest.GuestId = 4;
            suiteTest.Name = "Huset";
            suiteTest.Price = 2500;
            service.Update(suiteTest);
            Assert.Equal(suiteTest.Available, false);
            Assert.Equal(suiteTest.Name, "Huset");
            Assert.Equal(suiteTest.GuestId, 4);
            Assert.Equal(suiteTest.Price, 2500);
            service.Delete(suiteTest.Id);

            Assert.Null(service.GetById(suiteTest.Id));
        }
        [Fact]
        //First we creates a userBO with a name,password and role, then it reads if the properties are what we expect, then we grab the the properties and update them which we then check if they have been updated, after that we then delete the userBO and end the test checking if the suiteBO has been deleted or if it still exist
        public void CRUDTestUsers()
        {
            IUserTestService _service = new UserServiceTestMock();
            var UserTest = _service.Create(new UserBO
            {
                Username = "skipperBent1",
                Password = "Bente1",
                Role = "Administrator"
            });

            var id = UserTest.Id;
            Assert.NotNull(UserTest);
            Assert.Equal(UserTest.Username, "skipperBent1");
            Assert.Equal(UserTest.Password, "Bente1");
            Assert.Equal(UserTest.Role, "Administrator");
            Assert.Equal(_service.GetById(id).Username, "skipperBent1");
            Assert.Equal(_service.GetById(id).Password, "Bente1");
            Assert.Equal(_service.GetById(id).Role, "Administrator");
            UserTest.Username = "lars";
            UserTest.Password = "bent";
            UserTest.Role = "Guest";
            _service.Update(UserTest);
            Assert.Equal(UserTest.Password, "bent");
            Assert.Equal(UserTest.Username, "lars");
            Assert.Equal(UserTest.Role, "Guest");
            _service.Delete(UserTest.Id);

            Assert.Null(_service.GetById(UserTest.Id));
        }
    }
}