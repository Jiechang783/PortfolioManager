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
    public class PortfolioHistoyController : ApiController
    {
        [HttpGet]
        [Route("api/PortfolioHistorys")]
        public IHttpActionResult Get()
        {
            return Ok(PortfolioHistoryDao.getPortfolioHistorys());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/PortfolioHistorys/{id}")]
        public IHttpActionResult Get(int id)
        {
            PortfolioHistory p = PortfolioHistoryDao.getPortfolioHistorysById(id);
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
        [Route("api/PortfolioHistorysPId/{id}")]
        public IHttpActionResult GetByPid(int id)
        {
            List<PortfolioHistory> p = PortfolioHistoryDao.getPortfolioHistorysByPId(id);
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
        [Route("api/addPortfolioHistorys")]
        public IHttpActionResult addPortfolioHistorys(PortfolioHistory c)
        {
            PortfolioHistory c1 = new PortfolioHistory{ Id=1, PortfolioId=1, Date=Convert.ToDateTime("1992-03-20"), PNL=0.387 };
            int changeLine = PortfolioHistoryDao.setPortfolioHistory(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deletePortfolioHistorys")]
        public IHttpActionResult deletePortfolioHistorys(PortfolioHistory c)
        {

            int changeLine = PortfolioHistoryDao.deletePortfolioHistorys(c);
            return Ok(changeLine);
        }
    }
}
