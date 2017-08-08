using EntityFramwork.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
   public class FutureDao
    {
        public void FuturesDao()
        {
        }

        public static int addFuture(Future Future)
        {
            //  Futures b = new Futures() { FuturesId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Futures.Add(Future);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deleteFuture(Future Future)
        {
            // Futures b = new Futures() { FuturesId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                var removeFuture = db.Futures.FirstOrDefault(row => row.Isin == Future.Isin);

                if (removeFuture != null)
                {
                    db.Futures.Remove(removeFuture);
                }

                int result = db.SaveChanges();
                return result;
            }
        }

        public static List<Future> getFutures()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Future> Futures = new List<Future>();

                foreach (Future Future in db.Futures)
                {
                    Futures.Add(Future);
                }

                return Futures;
            }
        }

        public static Future getFutureByClr(string Isin)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Future> uers = new List<Future>();

                foreach (Future Future in db.Futures)
                {
                    if (Future.Isin == Isin)
                    {
                        return Future;
                    }
                }

                return null;
            }
        }

        public static int updateFuture(Future Future)
        {
            DatabaseContext db = new DatabaseContext();
            Future updateFuture = db.Futures.Single(x => x.Isin == Future.Isin);

            if (updateFuture == null)
            {
                throw new ArgumentOutOfRangeException("Web Service");
            }

            db.Entry(updateFuture).CurrentValues.SetValues(Future);  //更新实体
            int result = db.SaveChanges();
            return result;
        }
    }
}
