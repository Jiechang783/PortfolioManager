using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
    public class PortfolioDao
    {
        public PortfolioDao()
        {
        }


        public static int addPortfolio(Portfolio portfolio)
        {
            //  Portfolio b = new Portfolio() { PortfolioId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Portfolios.Add(portfolio);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deletePortfolios(Portfolio b)
        {
            // Portfolio b = new Portfolio() { PortfolioId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext context = new DatabaseContext())
            {
                var Portfolio = context.Portfolios.FirstOrDefault(row => row.PortfolioId == b.PortfolioId);
                if (Portfolio != null)
                {
                    context.Portfolios.Remove(Portfolio);
                }

                //db.Portfolios.Remove(b);
                int result = context.SaveChanges();
                return result;
            }
        }




        public static List<Portfolio> getPortfolios()
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Portfolio> uers = new List<Portfolio>();
                foreach (Portfolio temp in db.Portfolios)
                {
                    uers.Add(temp);
                }
                return uers;
            }
        }

        public static Portfolio getPortfoliosById(int id)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Portfolio> uers = new List<Portfolio>();
                foreach (Portfolio temp in db.Portfolios)
                {
                    if (temp.PortfolioId == id)
                    {
                        return temp;
                    }
                }
                return null;
            }
        }

        public static List<Portfolio> getPortfoliosByUserId(int id)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Portfolio> uers = new List<Portfolio>();
                foreach (Portfolio temp in db.Portfolios)
                {
                    if (temp.UserId == id)
                    {
                        uers.Add(temp);
                    }
                }
                return uers;
            }
        }

        public static int updatePortfolios(Portfolio w)
        {

            DatabaseContext db = new DatabaseContext();
            Portfolio us = db.Portfolios.Single(x => x.PortfolioId == w.PortfolioId);
            if (us == null)
                throw new ArgumentOutOfRangeException("ws");
            db.Entry(us).CurrentValues.SetValues(w);  //更新实体
            int result = db.SaveChanges();
            return result;
        }
    }
}
