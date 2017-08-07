using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
   public class UserDao
    {
        public UserDao() { }

        public static int  setUser(User a)
        {

            User b = new User() { UserId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role="admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Users.Add(a);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deleteUsers(User b)
        {
           // User b = new User() { UserId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext context = new DatabaseContext())
            {
                var user = context.Users.FirstOrDefault(row => row.UserId == b.UserId);
                if (user != null)
                {
                    context.Users.Remove(user);
                }
                    
                //db.Users.Remove(b);
                int result = context.SaveChanges();
                return result;
            }
        }




        public static List<User> getUsers()
        {
            
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<User> uers = new List<User>();
                foreach (User temp in db.Users)
                {
                    uers.Add(temp);
                }
                return uers;
            }
        }

        public static User getUsersById(int id)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<User> uers = new List<User>();
                foreach (User temp in db.Users)
                {
                    if (temp.UserId == id) {
                        return temp;
                    } 
                }
                return null;
            }
        }

        public static int updateUsers(User w)
        {
           
            DatabaseContext db = new DatabaseContext();
            User us = db.Users.Single(x => x.UserId == w.UserId);
            if (us == null)
                throw new ArgumentOutOfRangeException("ws");
            db.Entry(us).CurrentValues.SetValues(w);  //更新实体
            int result = db.SaveChanges();
            return result;
        }
    }
}

