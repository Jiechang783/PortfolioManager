using EntityFramwork.Entities;
using EntityFramwork.EntityDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorWervice.Models;

namespace AdministratorWervice.Controllers
{
    public class PortfolioController : ApiController
    {
        [HttpGet]
        [Route("api/AllPortfolios")]
        public IHttpActionResult Get()
        {
            List<Portfolio> list = PortfolioDao.getPortfolios();
            List<Portfolioinfo> returnlist = new List<Portfolioinfo>();
            foreach(Portfolio p in list)
            {
                returnlist.Add(new Portfolioinfo(p.PortfolioId, p.Name, UserDao.getUsersById(p.UserId).FirstName +" "
                    + UserDao.getUsersById(p.UserId).LastName, PortfolioHistoryDao.getLastPortfolioHistorysByPId(p.PortfolioId).PNL));

            }
            
            return Ok(returnlist);
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
        [Route("api/worstPortfolios/")]
        public IHttpActionResult Getworstportfolio()
        {
            List<Portfolio> portlist = PortfolioDao.getPortfolios();
            List<Portfolioandpnl> list = new List<Portfolioandpnl>();
            foreach (Portfolio p in portlist)
            {
                list.Add(new Portfolioandpnl(p.PortfolioId, p.Name,UserDao.getUsersById(p.UserId).FirstName+" "+
                   UserDao.getUsersById(p.UserId).LastName, PortfolioHistoryDao.getLastPortfolioHistorysByPId(p.PortfolioId).PNL));
            }
            var query = from p in list
                        orderby p.PNL
                        select new { p.PortfolioName,p.ManagerName ,p.PNL };


            return Ok(query.Take(1));
        }


        [HttpGet]
        [Route("api/bestPortfolios/")]
        public IHttpActionResult Getbestportfolio()
        {
            List<Portfolio> portlist = PortfolioDao.getPortfolios();
            List<Portfolioandpnl> list = new List<Portfolioandpnl>();
            foreach (Portfolio p in portlist)
            {
                list.Add(new Portfolioandpnl(p.PortfolioId, p.Name, UserDao.getUsersById(p.UserId).FirstName + " " +
                   UserDao.getUsersById(p.UserId).LastName, PortfolioHistoryDao.getLastPortfolioHistorysByPId(p.PortfolioId).PNL));
            }
            var query = from p in list
                        orderby p.PNL descending
                        select new { p.PortfolioName, p.ManagerName, p.PNL };


            return Ok(query.Take(1));
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

        [HttpGet]
        [Route("api/GetBestManager")]
        public IHttpActionResult GetBestmanager()
        {
            List<Portfolio> list = PortfolioDao.getPortfolios();
            List<Portfolioinfo> returnlist = new List<Portfolioinfo>();
            foreach (Portfolio p in list)
            {
                returnlist.Add(new Portfolioinfo(p.PortfolioId, p.Name, UserDao.getUsersById(p.UserId).FirstName + " "
                    + UserDao.getUsersById(p.UserId).LastName, PortfolioHistoryDao.getLastPortfolioHistorysByPId(p.PortfolioId).PNL));

            }

            return Ok(returnlist);
        }



    }
}
