using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramwork.EntityDao
{
    public class BondsDao
    {
        public BondsDao()
        {
        }

        public static int addBond(Bond bond)
        {
            //  Bonds b = new Bonds() { BondsId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Bonds.Add(bond);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deleteBond(Bond bond)
        {
            // Bonds b = new Bonds() { BondsId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                var removeBond = db.Bonds.FirstOrDefault(row => row.Isin == bond.Isin);

                if (removeBond != null)
                {
                    db.Bonds.Remove(removeBond);
                }

                int result = db.SaveChanges();
                return result;
            }
        }

        public static List<Bond> getBonds()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Bond> bonds = new List<Bond>();

                foreach (Bond bond in db.Bonds)
                {
                    bonds.Add(bond);
                }

                return bonds;
            }
        }

        public static Bond getBondById(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Bond> uers = new List<Bond>();

                foreach (Bond bond in db.Bonds)
                {
                    if (bond.Isin == id)
                    {
                        return bond;
                    }
                }

                return null;
            }
        }

        public static int updateBond(Bond bond)
        {
            DatabaseContext db = new DatabaseContext();
            Bond updateBond = db.Bonds.Single(x => x.Isin == bond.Isin);

            if (updateBond == null)
            {
                throw new ArgumentOutOfRangeException("Web Service");
            }

            db.Entry(updateBond).CurrentValues.SetValues(bond);  //更新实体
            int result = db.SaveChanges();
            return result;
        }
    }
}
