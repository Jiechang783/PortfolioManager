using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityFramwork.Entities;
using EntityFramwork.EntityDao;
using PortfolioManagerService.Models;

namespace PortfolioManagerService.Controllers
{
    public class StockController : ApiController
    {
        [HttpGet]
        [Route("api/PM/Stock")]
        public IHttpActionResult Get()
        {
            return Ok(StockDao.getStocks());
        }

        [HttpPost]
        [Route("api/PM/updatestockprice")]
        public IHttpActionResult Updatestockprice(dynamic price)
        {
            PriceHistory history = new PriceHistory();
            history.Isin = price.isin;
            history.OfferPrice = price.OfferPrice;
            history.Type = "Stock";
            history.BidPrice = price.BidPrice;
            history.Date = DateTime.Now;

            int changeline=PriceHistoryDao.setPriceHistory(history);

            List<Position> positions = PositionDao.getPositionsByIsin(history.Isin);
            Portfolio portfolio = new Portfolio();
            foreach (Position p in positions)
            {
                portfolio = PortfolioDao.getPortfoliosById(p.PortfolioId);
                double pnl = Getportfoliopnl(portfolio.PortfolioId);
                PortfolioHistory porthistory = new PortfolioHistory();
                porthistory.PNL = pnl;
                porthistory.Date = DateTime.Now;
                porthistory.PortfolioId = portfolio.PortfolioId;
                int line = PortfolioHistoryDao.setPortfolioHistory(porthistory);

            }

            return Ok("success");
        }



        [HttpPost]
        [Route("api/PM/Security")]
        public IHttpActionResult GetSecurity(dynamic security)
        {
            if(security.type=="Stock")
            {
                string isin = security.isin;
                return Ok(StockDao.getStocksByIsin(isin));
            }
            else if(security.type == "Bond")
            {
                string isin = security.isin;
                return Ok(BondsDao.getBondsByIsin(isin));
            }
            else
            {
                string isin = security.isin;
                return Ok(FutureDao.getFutureByIsin(isin));
            }
            
                
        }




        [HttpGet]
        [Route("api/PM/Stocklist")]
        public IHttpActionResult Getstocklist()
        {

            return Ok();
        }




        [HttpGet]
        // GET api/values/5
        [Route("api/PM/Stocks/{isin}")]
        public IHttpActionResult Get(string isin)
        {
            Stock p = StockDao.getStocksByIsin(isin);
            if (p != null)
            {
                return Ok(p);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        // GET api/values/5
        [Route("api/PM/Securityinfo/{isin}")]
        public IHttpActionResult Getstockavg(string isin)
        {
            List<PriceHistory> p = PriceHistoryDao.getPriceHistorysByisin(isin);
            decimal avg = (from stock in p
                         select stock.OfferPrice).Average();
            decimal max = (from stock in p
                       select stock.OfferPrice).Max();
            decimal min = (from stock in p
                       select stock.OfferPrice).Min();
            decimal offer = PriceHistoryDao.getLastPriceHistorysByisin(isin).OfferPrice;
            decimal bid = PriceHistoryDao.getLastPriceHistorysByisin(isin).BidPrice;

            return Ok(new Securityinfo(avg,max,min,offer,bid));

        }



        [HttpPost]
        [Route("api/PM/UpdateStocks")]
        public IHttpActionResult updateStockById(Stock c)
        {

            int changeLine = StockDao.updateStocks(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/PM/addStocks")]
        public IHttpActionResult addStocks(Stock c)
        {
            // Stock c1 = new Stock { Isin = 1, Name = "ztt", Symbol = "ztt", LastSale = 0, MarketCap = 0, IPOyear = Convert.ToDateTime("1975-06-04 00:00:00.000"), Sector = "sad", industry = "djh", SummaryQuote = "dasd", Address = "sad" };
            int changeLine = StockDao.setStock(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/PM/deleteStocks")]
        public IHttpActionResult deleteStocks(Stock c)
        {

            int changeLine = StockDao.deleteStocks(c);
            return Ok(changeLine);
        }

        public static double Getportfoliopnl(int portid)
        {
            decimal amountbefore = 0;
            decimal amountafter = 0;
            double pnl = 0;
            List<Position> posilist = PositionDao.getPositionsByPortfolioId(portid);
            foreach (Position p in posilist)
            {
                string isin = p.Isin;
                amountbefore += p.Quantity * p.Price;
                amountafter += p.Quantity * PriceHistoryDao.getLastPriceHistorysByisin(isin).OfferPrice;
            }
            pnl = Convert.ToDouble((amountafter - amountbefore) / amountbefore);
            return pnl;
        }
    }
}
