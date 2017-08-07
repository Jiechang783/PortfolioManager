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
    public class StockController : ApiController
    {
        [HttpGet]
        [Route("api/Stock")]
        public IHttpActionResult Get()
        {
            return Ok(StockDao.getStocks());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Stocks/{id}")]
        public IHttpActionResult Get(int id)
        {
            Stock p = StockDao.getStocksById(id);
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
        [Route("api/UpdateStocks")]
        public IHttpActionResult updateStockById(Stock c)
        {

            int changeLine = StockDao.updateStocks(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addStocks")]
        public IHttpActionResult addStocks(dynamic c)
        {
            // Stock c1 = new Stock { Isin = 1, Name = "ztt", Symbol = "ztt", LastSale = 0, MarketCap = 0, IPOyear = Convert.ToDateTime("1975-06-04 00:00:00.000"), Sector = "sad", industry = "djh", SummaryQuote = "dasd", Address = "sad" };

            int changeLine = StockDao.setStock(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deleteStocks")]
        public IHttpActionResult deleteStocks(Stock c)
        {
            
            int changeLine = StockDao.deleteStocks(c);
            return Ok(changeLine);
        }

        [HttpGet]
        [Route("api/GetStockBySector")]
        public IHttpActionResult GetStockBySector(Sector c)
        {

            Sector c1 = new Sector {SectorId=0,Name="sdf" };
            return Ok(StockDao.getStockListBySector(c1));
        }

        [HttpGet]
        [Route("api/GetStockByIndustry")]
        public IHttpActionResult GetStockByIndustry(Industry c)
        {

            Industry c1 = new Industry { IndustryId = 0, Name = "ztt" };
            return Ok(StockDao.getStockListByIndustry(c1));
        }
    }
}
