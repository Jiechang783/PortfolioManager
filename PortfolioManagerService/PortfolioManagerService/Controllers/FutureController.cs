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
    }
}
