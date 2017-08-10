﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityFramwork.EntityDao;
using EntityFramwork.Entities;

namespace PortfolioManagerService.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/Users")]
        public IHttpActionResult Get()
        {
            return Ok(UserDao.getUsers());
        }


        [HttpGet]
        // GET api/values/5
        [Route("api/Users/{id}")]
        public IHttpActionResult Get(int id)
        {
            User p = UserDao.getUsersById(id);
            if (p != null)
            {
                return Ok(p);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("api/Login")]
        public IHttpActionResult Login(User c)
        {

            User u=UserDao.getUserByEmail(c);
            //User c1 = new User { UserId = 1, FirstName = "ztt", LastName = "ztt", Email = " 0", telephone = "0", Role = "admin" };
            List<User> users = new List<User>();
            if(u==null)
            {
                return Ok();
            }
            users.Add(u);
            var query = from user in users
                        select new { user.UserId, user.Role };
            return Ok(query);
        }


        [HttpPost]
        [Route("api/UpdateUsers")]
        public IHttpActionResult updateUserById(User c)
        {

            int changeLine = UserDao.updateUsers(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addUsers")]
        public IHttpActionResult addUsers(User c)
        {
            User c1 = new User { UserId = 1, FirstName = "ztt", LastName = "ztt", Email = " 0", telephone = "0", Role = "admin" };
            int changeLine = UserDao.setUser(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deleteUsers")]
        public IHttpActionResult deleteUsers(User c)
        {
            //  User c1 = new User(Convert.ToInt32(d),"ztt", "ztt", 0, "1975-06-04 00:00:00.000");
            int changeLine = UserDao.deleteUsers(c);
            return Ok(changeLine);
        }


    }
}
