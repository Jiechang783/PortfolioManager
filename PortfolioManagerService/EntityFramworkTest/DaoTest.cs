 using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFramwork.EntityDao;
using EntityFramwork.Entities;

namespace EntityFramworkTest
{
    [TestClass]
    public class DaoTest
    {  

        [TestInitialize]
        public void InitalDao() {


        }

        [TestMethod]
        public void UserDaoTest()
        {
            User u = new User { UserId = 1, FirstName = "zhang", LastName = "Tingting",Password="aisudie", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            int result = UserDao.setUser(u);
            Assert.AreEqual(1,result);
        }


    }
}
