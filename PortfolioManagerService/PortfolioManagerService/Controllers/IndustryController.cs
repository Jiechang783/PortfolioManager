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
    public class IndustryController : ApiController
    {
        [HttpGet]
        [Route("api/Industry")]
        public IHttpActionResult Get()
        {
            return Ok(IndustryDao.getIndustrys());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Industry/{id}")]
        public IHttpActionResult Get(int id)
        {
            Industry p = IndustryDao.getIndustryByIndustryId(id);
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
        [Route("api/UpdateIndustry")]
        public IHttpActionResult updateBondsById(Industry c)
        {

            int changeLine = IndustryDao.updateIndustry(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addIndustry")]
        public IHttpActionResult addIndustry(Industry c)
        {
            // Industry c1 = new Industry { IndustryId=1, Name="ztt" };
            int changeLine = IndustryDao.addIndustry(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deleteIndustry")]
        public IHttpActionResult deleteIndustry(Industry c)
        {

            int changeLine = IndustryDao.deleteIndustry(c);
            return Ok(changeLine);
        }
    }
}
