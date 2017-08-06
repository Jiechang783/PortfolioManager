using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
   public class BondsDao
    {
        public BondsDao()
        {

        }

        public static int setBonds(Bonds a)
        {

            //  Bonds b = new Bonds() { BondsId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Bondses.Add(a);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deleteBondss(Bonds b)
        {
            // Bonds b = new Bonds() { BondsId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext context = new DatabaseContext())
            {
                var Bonds = context.Bondses.FirstOrDefault(row => row.Isin == b.Isin);
                if (Bonds != null)
                {
                    context.Bondses.Remove(Bonds);
                }

                //db.Bondss.Remove(b);
                int result = context.SaveChanges();
                return result;
            }
        }




        public static List<Bonds> getBondss()
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Bonds> uers = new List<Bonds>();
                foreach (Bonds temp in db.Bondses)
                {
                    uers.Add(temp);
                }
                return uers;
            }
        }

        public static Bonds getBondssById(int id)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Bonds> uers = new List<Bonds>();
                foreach (Bonds temp in db.Bondses)
                {
                    if (temp.Isin == id)
                    {
                        return temp;
                    }
                }
                return null;
            }
        }

        public static int updateBondss(Bonds w)
        {

            DatabaseContext db = new DatabaseContext();
            Bonds us = db.Bondses.Single(x => x.Isin == w.Isin);
            if (us == null)
                throw new ArgumentOutOfRangeException("ws");
            db.Entry(us).CurrentValues.SetValues(w);  //更新实体
            int result = db.SaveChanges();
            return result;
        }
    }
}
