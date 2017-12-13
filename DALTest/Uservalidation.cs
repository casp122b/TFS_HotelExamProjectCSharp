using System;
using System.Text.RegularExpressions;
using DAL;
using DAL.Entities;
using NUnit.Framework;


namespace DALTest
{
    [TestFixture]
    public class UservalidationTest
    {
        [Test]
        public void NullTestUser()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => new UserValidation(null));
            Assert.AreEqual("User cannot be null", exception.Message);
        }

        [Test]
        public void NullTestUserName()
        {
            var user = new User() { Username = null };
            var exception = Assert.Throws<ArgumentException>(
                () => new UserValidation(user));
            Assert.AreEqual("Username cannot be null", exception.Message);

        }
     
        }
    }

