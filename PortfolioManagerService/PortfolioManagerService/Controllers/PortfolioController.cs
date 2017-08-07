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
    public class PortfolioController : ApiController
    {
        [HttpGet]
        [Route("api/Portfolios")]
        public IHttpActionResult Get()
        {
            return Ok(PortfolioDao.getPortfolios());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Portfolios/{id}")]
        public IHttpActionResult Get(int id)
        {
            Portfolio p = PortfolioDao.getPortfoliosById(id);
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
        [Route("api/ALLPortfolios/{userid}")]
        public IHttpActionResult Getallportfolio(int userid)
        {
            List<Portfolio> portlist = PortfolioDao.getPortfoliosByUserId(userid);
            List<Portfilioandpnl> list = new List<Portfilioandpnl>();
            foreach(Portfolio p in portlist)
            {
                list.Add(new Portfilioandpnl(p.PortfolioId, p.Name, PortfolioHistoryDao.getLastPortfolioHistorysByPId(p.PortfolioId).PNL));
            }

            return Ok(list);
        }

        [HttpGet]
        [Route("api/bestPortfolios/{userid}")]
        public IHttpActionResult Getbestportfolio(int userid)
        {
            List<Portfolio> portlist = PortfolioDao.getPortfoliosByUserId(userid);
            List<Portfilioandpnl> list = new List<Portfilioandpnl>();
            foreach (Portfolio p in portlist)
            {
                list.Add(new Portfilioandpnl(p.PortfolioId, p.Name, PortfolioHistoryDao.getLastPortfolioHistorysByPId(p.PortfolioId).PNL));
            }
            var query = from p in list
                        orderby p.PNL descending
                        select new { p.portfolioname, p.PNL };
            

            return Ok(query.Take(1));
        }

        [HttpGet]
        [Route("api/worstPortfolios/{userid}")]
        public IHttpActionResult Getworstportfolio(int userid)
        {
            List<Portfolio> portlist = PortfolioDao.getPortfoliosByUserId(userid);
            List<Portfilioandpnl> list = new List<Portfilioandpnl>();
            foreach (Portfolio p in portlist)
            {
                list.Add(new Portfilioandpnl(p.PortfolioId, p.Name, PortfolioHistoryDao.getLastPortfolioHistorysByPId(p.PortfolioId).PNL));
            }
            var query = from p in list
                        orderby p.PNL
                        select new { p.portfolioname, p.PNL };


            return Ok(query.Take(1));
            return Ok(list);
        }



        [HttpPost]
        [Route("api/UpdatePortfolios")]
        public IHttpActionResult updatePortfolioById(Portfolio c)
        {

            int changeLine = PortfolioDao.updatePortfolios(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addPortfolios")]
        public IHttpActionResult addPortfolios(Portfolio c)
        {

            int changeLine = PortfolioDao.addPortfolio(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deletePortfolios")]
        public IHttpActionResult deletePortfolios(Portfolio c)
        {

            int changeLine = PortfolioDao.deletePortfolios(c);
            return Ok(changeLine);
        }


    }
}
