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
    public class BondsController : ApiController
    {
        [HttpGet]
        [Route("api/Bonds")]
        public IHttpActionResult Get()
        {
            return Ok(BondsDao.getBondss());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Bondss/{id}")]
        public IHttpActionResult Get(int id)
        {
            Bonds p = BondsDao.getBondssById(id);
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
        [Route("api/UpdateBondss")]
        public IHttpActionResult updateBondsById(Bonds c)
        {

            int changeLine = BondsDao.updateBondss(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addBondss")]
        public IHttpActionResult addBondss(Bonds c)
        {

            int changeLine = BondsDao.setBonds(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deleteBondss")]
        public IHttpActionResult deleteBondss(Bonds c)
        {
            Bonds c1 = new Bonds { Isin=1, Issuer="ztt", Coupon=3.3, MaturityMonth="0", MaturityYear= Convert.ToDateTime("1975-06-04") };
            int changeLine = BondsDao.deleteBondss(c);
            return Ok(changeLine);
        }

    }
}
