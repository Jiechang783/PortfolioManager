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
    public class BondController : ApiController
    {
        [HttpGet]
        [Route("api/Bonds")]
        public IHttpActionResult Get()
        {

            return Ok(BondsDao.getBonds().Take(100));
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Bondss/{isin}")]
        public IHttpActionResult Get(string isin)
        {
            Bond p = BondsDao.getBondsByIsin(isin);
            if (p != null)
            {
                return Ok(p);
            }
            else
            {
                return NotFound();
            }

        }


        [HttpPost]
        [Route("api/PM/updatebondprice")]
        public IHttpActionResult Updatestockprice(dynamic price)
        {
            PriceHistory history = new PriceHistory();
            history.Isin = price.isin;
            history.OfferPrice = price.OfferPrice;
            history.Type = "Bond";
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
        [Route("api/UpdateBondss")]
        public IHttpActionResult updateBondsById(Bond c)
        {

            int changeLine = BondsDao.updateBond(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addBondss")]
        public IHttpActionResult addBondss(Bond c)
        {

            int changeLine = BondsDao.addBond(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deleteBondss")]
        public IHttpActionResult deleteBondss(Bond c)
        {
            
            int changeLine = BondsDao.deleteBond(c);
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
