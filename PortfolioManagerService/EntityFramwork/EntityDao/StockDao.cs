using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static List<Stock> getStockListBySector(Sector sector)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                if (sector == null) return null;
                if (sector.SectorId != 0)
                {  //默认数据补全为0                   
                    List<Stock> st = new List<Stock>();
                    foreach (Stock temp in db.Stocks)
                    {
                        if (temp.SectorId == sector.SectorId)
                        {
                            st.Add(temp);
                        }
                    }
                }
                else if(sector.Name != null) {
                    var joinStock = db.Stocks.Join(db.Sectors, a => a.SectorId, g => g.SectorId, (a, g) => new { a.Isin,a.Name,a.Symbol,a.LastSale,a.MarketCap, a.IPOyear,a.SectorId,a.IndustryId,a.SummaryQuote,a.Address}).ToList();
                    var joinSector = db.Stocks.Join(db.Sectors, a => a.SectorId, g => g.SectorId, (a, g) => new {g.SectorId,g.Name }).ToList();
                    int id = 0;
                    foreach (var sec in joinSector) {
                        if (sector.Name.Equals(sec.Name)) {
                            id = sec.SectorId;
                        }
                    }

                    List<Stock> stocks = new List<Stock>();
                    Stock stock = new Stock();
                    foreach (var s in joinStock) {

                        if (s.SectorId == id) {
                            stock.SectorId = s.SectorId;
                            stock.Name = s.Name;
                            stock.Symbol = s.Symbol;
                            stock.Isin = s.Isin;
                            stock.LastSale = s.LastSale;
                            stock.MarketCap = s.MarketCap;
                            stock.IPOyear = s.IPOyear;
                            stock.IndustryId = s.IndustryId;
                            stock.SummaryQuote = s.SummaryQuote;
                            stock.Address = s.Address;
                            stocks.Add(stock);
                        }
                    }

                    return stocks;
                }

            }

            return null;
        }


        public static List<Stock> getStockListByIndustry(Industry industry)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                if (industry == null) return null;
                if (industry.IndustryId != 0)
                {  //默认数据补全为0                   
                    List<Stock> st = new List<Stock>();
                    foreach (Stock temp in db.Stocks)
                    {
                        if (temp.IndustryId == industry.IndustryId)
                        {
                            st.Add(temp);
                        }
                    }
                }
                else if (industry.Name != null)
                {
                    var joinStock = db.Stocks.Join(db.Industrys, a => a.IndustryId, g => g.IndustryId, (a, g) => new { a.Isin, a.Name, a.Symbol, a.LastSale, a.MarketCap, a.IPOyear, a.SectorId, a.IndustryId, a.SummaryQuote, a.Address }).ToList();
                    var joinIndustry = db.Stocks.Join(db.Industrys, a => a.IndustryId, g => g.IndustryId, (a, g) => new { g.IndustryId, g.Name }).ToList();
                    int id = 0;
                    foreach (var sec in joinIndustry)
                    {
                        if (industry.Name.Equals(sec.Name))
                        {
                            id = sec.IndustryId;
                        }
                    }

                    List<Stock> stocks = new List<Stock>();
                    Stock stock = new Stock();
                    foreach (var s in joinStock)
                    {

                        if (s.IndustryId == id)
                        {
                            stock.IndustryId = s.IndustryId;
                            stock.Name = s.Name;
                            stock.Symbol = s.Symbol;
                            stock.Isin = s.Isin;
                            stock.LastSale = s.LastSale;
                            stock.MarketCap = s.MarketCap;
                            stock.IPOyear = s.IPOyear;
                            stock.IndustryId = s.IndustryId;
                            stock.SummaryQuote = s.SummaryQuote;
                            stock.Address = s.Address;
                            stocks.Add(stock);
                        }
                    }

                    return stocks;
                }

            }

            return null;
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
