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
    public class SectorController : ApiController
    {
        [HttpGet]
        [Route("api/Sector")]
        public IHttpActionResult Get()
        {
            return Ok(SectorDao.getSectors());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Sector/{id}")]
        public IHttpActionResult Get(int id)
        {
            Sector p = SectorDao.getSectorBySectorId(id);
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
        [Route("api/UpdateSector")]
        public IHttpActionResult updateBondsById(Sector c)
        {

            int changeLine = SectorDao.updateSector(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addSector")]
        public IHttpActionResult addSector(dynamic c)
        {

            int changeLine = SectorDao.addSector(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deleteSector")]
        public IHttpActionResult deleteSector(Sector c)
        {
            //Bond c1 = new Bond { Isin=1, Issuer="ztt", Coupon=3.3, MaturityMonth="0", MaturityYear= Convert.ToDateTime("1975-06-04") };
            int changeLine = SectorDao.deleteSector(c);
            return Ok(changeLine);
        }
    }
}
