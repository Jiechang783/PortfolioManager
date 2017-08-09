using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityFramwork.Entities;
using EntityFramwork.EntityDao;

namespace PortfolioManagerService.Controllers
{
    public class FutureController : ApiController
    {
        [HttpGet]
        [Route("api/Futures")]
        public IHttpActionResult Get()
        {
            return Ok(FutureDao.getFutures());

        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Futures/{isin}")]
        public IHttpActionResult Get(string isin)
        {
            Future p = FutureDao.getFutureByIsin(isin);
            if (p != null)
            {
                return Ok(p);
            }
            else
            {
                return NotFound();
            }

        }

        [Route("api/PM/updatefutureprice")]
        public IHttpActionResult UpdateFutureprice(dynamic price)
        {
            PriceHistory history = new PriceHistory();
            history.Isin = price.isin;
            history.OfferPrice = price.OfferPrice;
            history.Type = "Future";
            history.BidPrice = price.BidPrice;
            history.Date = DateTime.Now;

            int changeline = PriceHistoryDao.setPriceHistory(history);

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

            return Ok();
        }


        [HttpPost]
        [Route("api/UpdateFutures")]
        public IHttpActionResult updateBondsById(Future c)
        {

            int changeLine = FutureDao.updateFuture(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addFutures")]
        public IHttpActionResult addBondss(Future c)
        {

            int changeLine = FutureDao.addFuture(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deleteFuture")]
        public IHttpActionResult deleteBondss(Future c)
        {
            int changeLine = FutureDao.deleteFuture(c);
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
