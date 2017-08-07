using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
   public class PriceHistoryDao
    {
        public PriceHistoryDao() { }


        public static int setPriceHistory(PriceHistory a)
        {

            //  Portfolio b = new Portfolio() { PortfolioId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.PriceHistorys.Add(a);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deletePriceHistorys(PriceHistory b)
        {
            // PriceHistory b = new PriceHistory() { PriceHistoryId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext context = new DatabaseContext())
            {
                var PriceHistory = context.PriceHistorys.FirstOrDefault(row => row.Id == b.Id);
                if (PriceHistory != null)
                {
                    context.PriceHistorys.Remove(PriceHistory);
                }

                //db.PriceHistorys.Remove(b);
                int result = context.SaveChanges();
                return result;
            }
        }




        public static List<PriceHistory> getPriceHistorys()
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<PriceHistory> uers = new List<PriceHistory>();
                foreach (PriceHistory temp in db.PriceHistorys)
                {
                    uers.Add(temp);
                }
                return uers;
            }
        }

        public static PriceHistory getPriceHistorysById(int id)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<PriceHistory> uers = new List<PriceHistory>();
                foreach (PriceHistory temp in db.PriceHistorys)
                {
                    if (temp.Id == id)
                    {
                        return temp;
                    }
                }
                return null;
            }
        }

        public static List<PriceHistory> getPriceHistorysByisin(int isin)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<PriceHistory> uers = new List<PriceHistory>();
                foreach (PriceHistory temp in db.PriceHistorys)
                {
                    if (temp.Isin == isin)
                    {
                        uers.Add(temp);
                    }
                }
                return uers;
            }
        }

    }
}
