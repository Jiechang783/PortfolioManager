using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdministratorWervice.Controllers;
using EntityFramwork.Entities;

namespace AdministratorWervice.Tests
{
    [TestClass]
    public class AdminTest
    {
        [TestClass]
        public class AdminControllerTest
        {
            AdminController c;

            [TestInitialize]
            public void initalMethod()
            {
                c = new AdminController();
            }

            [TestMethod]
            public void TestMethod1()
            {
                Assert.IsNotNull(c);
            }

            [TestMethod]
            public void TestupdateUserById()
            {
                User u = new User();
               
            }
        }
    }
}
