using EntityFramwork.Entities;
using EntityFramwork.EntityDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdministratorWervice.Controllers
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
        [Route("api/PriceHistorysPID/{id}")]
        public IHttpActionResult GetPId(int id)
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
            PriceHistory c1 = new PriceHistory { Id=1, Isin=3, Date=Convert.ToDateTime("1992-03-20"), Price=2 };
            int changeLine = PriceHistoryDao.deletePriceHistorys(c);
            return Ok(changeLine);
        }

        [HttpGet]
        [Route("api/Getpricehis/{isin}")]
        public IHttpActionResult Getresult(int isin)
        {
            var query = from p in PriceHistoryDao.getPriceHistorysByisin(isin)
                        select new { p.Date,p.Price};

            return Ok(query);
        }

    }
}
