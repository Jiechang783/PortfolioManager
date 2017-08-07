using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
   public class IndustryDao
    {
        public static int addIndustry(Industry industry)
        {
            //  Industrys b = new Industrys() { IndustrysId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Industrys.Add(industry);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deleteIndustry(Industry industry)
        {
            // Industrys b = new Industrys() { IndustrysId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                var removeIndustry = db.Industrys.FirstOrDefault(row => row.IndustryId == industry.IndustryId);

                if (removeIndustry != null)
                {
                    db.Industrys.Remove(removeIndustry);
                }

                int result = db.SaveChanges();
                return result;
            }
        }

        public static List<Industry> getIndustrys()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Industry> Industrys = new List<Industry>();

                foreach (Industry Industry in db.Industrys)
                {
                    Industrys.Add(Industry);
                }

                return Industrys;
            }
        }

        public static Industry getIndustryByIndustryId(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Industry> uers = new List<Industry>();

                foreach (Industry Industry in db.Industrys)
                {
                    if (Industry.IndustryId == id)
                    {
                        return Industry;
                    }
                }

                return null;
            }
        }

        public static int updateIndustry(Industry industry)
        {
            DatabaseContext db = new DatabaseContext();
            Industry updateIndustry = db.Industrys.Single(x => x.IndustryId == industry.IndustryId);

            if (updateIndustry == null)
            {
                throw new ArgumentOutOfRangeException("Web Service");
            }

            db.Entry(updateIndustry).CurrentValues.SetValues(industry);  //更新实体
            int result = db.SaveChanges();
            return result;
        }
    }
}
