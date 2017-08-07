using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
   public class StockDao
    {
        public StockDao() {

        }

        public static int setStock(Stock a)
        {

            //  Stock b = new Stock() { StockId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Stocks.Add(a);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deleteStocks(Stock b)
        {
            // Stock b = new Stock() { StockId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext context = new DatabaseContext())
            {
                var Stock = context.Stocks.FirstOrDefault(row => row.Isin == b.Isin);
                if (Stock != null)
                {
                    context.Stocks.Remove(Stock);
                }

                //db.Stocks.Remove(b);
                int result = context.SaveChanges();
                return result;
            }
        }




        public static List<Stock> getStocks()
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Stock> uers = new List<Stock>();
                foreach (Stock temp in db.Stocks)
                {
                    uers.Add(temp);
                }
                return uers;
            }
        }

        public static Stock getStocksById(int id)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Stock> uers = new List<Stock>();
                foreach (Stock temp in db.Stocks)
                {
                    if (temp.Isin == id)
                    {
                        return temp;
                    }
                }
                return null;
            }
        }

        public static int updateStocks(Stock w)
        {

            DatabaseContext db = new DatabaseContext();
            Stock us = db.Stocks.Single(x => x.Isin == w.Isin);
            if (us == null)
                throw new ArgumentOutOfRangeException("ws");
            db.Entry(us).CurrentValues.SetValues(w);  //更新实体
            int result = db.SaveChanges();
            return result;
        }

    }
}
