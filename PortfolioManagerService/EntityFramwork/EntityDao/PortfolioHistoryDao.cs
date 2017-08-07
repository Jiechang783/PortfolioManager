using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
   public class PortfolioHistoryDao
    {
        public static int setPortfolioHistory(PortfolioHistory a)
        {

            //  Portfolio b = new Portfolio() { PortfolioId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.PortfolioHistories.Add(a);
                int result = db.SaveChanges();
                return result;
            }
        }
        public static int deletePortfolioHistorys(PortfolioHistory b)
        {
            // PortfolioHistory b = new PortfolioHistory() { PortfolioHistoryId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext context = new DatabaseContext())
            {
                var PortfolioHistory = context.PortfolioHistories.FirstOrDefault(row => row.Id == b.Id);
                if (PortfolioHistory != null)
                {
                    context.PortfolioHistories.Remove(PortfolioHistory);
                }

                //db.PortfolioHistorys.Remove(b);
                int result = context.SaveChanges();
                return result;
            }
        }




        public static List<PortfolioHistory> getPortfolioHistorys()
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<PortfolioHistory> uers = new List<PortfolioHistory>();
                foreach (PortfolioHistory temp in db.PortfolioHistories)
                {
                    uers.Add(temp);
                }
                return uers;
            }
        }

        public static PortfolioHistory getPortfolioHistorysById(int id)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<PortfolioHistory> uers = new List<PortfolioHistory>();
                foreach (PortfolioHistory temp in db.PortfolioHistories)
                {
                    if (temp.Id == id)
                    {
                        return temp;
                    }
                }
                return null;
            }
        }

        public static PortfolioHistory getLastPortfolioHistorysByPId(int portfolioId)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<PortfolioHistory> ph = new List<PortfolioHistory>();
                foreach (PortfolioHistory temp in db.PortfolioHistories)
                {
                    if (temp.PortfolioId == portfolioId)
                    {
                        ph.Add(temp);
                    }
                }
                if (ph.Count != 0)
                {
                    return ph[ph.Count - 1];
                }
                else
                {
                    return null;
                }

            }
        }

        public static List<PortfolioHistory> getPortfolioHistorysByPId(int portfolioId)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<PortfolioHistory> users = new List<PortfolioHistory>();
                foreach (PortfolioHistory temp in db.PortfolioHistories)
                {
                    if (temp.PortfolioId == portfolioId)
                    {
                        users.Add(temp);
                    }
                }
                return users;
            }
        }
    }
}
