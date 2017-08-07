using EntityFramwork;
using EntityFramwork.EntityDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdministratorWervice.Controllers
{
    public class FutureController : ApiController
    {
        [HttpGet]
        [Route("api/Future")]
        public IHttpActionResult Get()
        {
            return Ok(FutureDao.getFutures());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Future/{id}")]
        public IHttpActionResult Get(string id)
        {
            Future p = FutureDao.getFutureByClr(id);
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
        [Route("api/UpdateFuture")]
        public IHttpActionResult updateBondsById(Future c)
        {

            int changeLine = FutureDao.updateFuture(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addFuture")]
        public IHttpActionResult addFuture(Future c)
        {

            int changeLine = FutureDao.addFuture(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deleteFuture")]
        public IHttpActionResult deleteFuture(Future c)
        {
            //Bond c1 = new Bond { Isin=1, Issuer="ztt", Coupon=3.3, MaturityMonth="0", MaturityYear= Convert.ToDateTime("1975-06-04") };
            int changeLine = FutureDao.deleteFuture(c);
            return Ok(changeLine);
        }

    }
}
