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
    public class PriceHistoryController : ApiController
    {
        [HttpGet]
        [Route("api/PriceHistorys")]
        public IHttpActionResult Get()
        {
            return Ok(PriceHistoryDao.getPriceHistorys());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/PriceHistorys/{id}")]
        public IHttpActionResult Get(int id)
        {
            PriceHistory p = PriceHistoryDao.getPriceHistorysById(id);
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
        [Route("api/OneStockHistorys/{isin}")]
        public IHttpActionResult GetoneStockPrice(int isin)
        {
            List<PriceHistory> p = PriceHistoryDao.getPriceHistorysByisin(isin);
            List<Decimal> price = new List<decimal>();
            List<DateTime> time = new List<DateTime>();

            foreach(PriceHistory history in p)
            {
                price.Add(history.OfferPrice);
                time.Add(history.Date);
            }
            
            return Ok(new OneStockresult(time,price));

        }


        [HttpGet]
        // GET api/values/5
        [Route("api/AllStockHistorys")]
        public IHttpActionResult GetallStockPrice()
        {

            List<OneStockresult> Allresult = new List<OneStockresult>();
            List<PriceHistory> Pricehistory = PriceHistoryDao.getPriceHistorys();
            var query = (from p in Pricehistory
                         select p.Isin).Distinct();

            foreach(int isin in query)
            {
                List<Decimal> price = new List<decimal>();
                List<DateTime> time = new List<DateTime>();
                List<PriceHistory> result = PriceHistoryDao.getPriceHistorysByisin(isin);
                foreach(PriceHistory history in result)
                {
                    price.Add(history.OfferPrice);
                    time.Add(history.Date);
                }
                Allresult.Add(new OneStockresult(time, price));

            }

            return Ok(Allresult);

        }




        [HttpPost]
        [Route("api/addPriceHistorys")]
        public IHttpActionResult addPriceHistorys(PriceHistory c)
        {

            int changeLine = PriceHistoryDao.setPriceHistory(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deletePriceHistorys")]
        public IHttpActionResult deletePriceHistorys(PriceHistory c)
        {
           // PriceHistory c1 = new PriceHistory { Id = 1, Isin = 3, Date = Convert.ToDateTime("1992-03-20"), Price = 2 };
            int changeLine = PriceHistoryDao.deletePriceHistorys(c);
            return Ok(changeLine);
        }

        [HttpGet]
        [Route("api/Getpricehis/{isin}")]
        public IHttpActionResult Getresult(int isin)
        {
            var query = from p in PriceHistoryDao.getPriceHistorysByisin(isin)
                        select new { p.Date, p.OfferPrice };

            return Ok(query);
        }
    }
}
