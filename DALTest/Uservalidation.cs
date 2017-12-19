using DAL;
using DAL.Entities;
using System;
using Xunit;

namespace DALTest
{
    public class UservalidationTest
    {
        [Fact]
        public void NullTestUser()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => new UserValidation(null));
            Assert.Equal("User cannot be null", exception.Message);
        }

        [Fact]
        public void NullTestUserName()
        {
            var user = new User() { Username = null };
            var exception = Assert.Throws<ArgumentException>(
                () => new UserValidation(user));
            Assert.Equal("Username cannot be null", exception.Message);
        }
    }
}