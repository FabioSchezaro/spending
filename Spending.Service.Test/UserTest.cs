using NUnit.Framework;
using Spending.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spending.Service.Test
{
    public class UserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AuthenticateAsync_WhenLogged_MustBeTokenAccess()
        {
            UserEntity user = new UserEntity();
            user.Login = "admin";
            user.Password = "admin";


            Assert.Pass();
        }
    }
}
