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
        [Route("api/getPortfoliopnl/{portid}")]
        public IHttpActionResult Getportfoliopnl(int portid)
        {
            decimal amountbefore = 0;
            decimal amountafter = 0;
            double pnl = 0;
            List<Position> posilist = PositionDao.getPositionsByPortfolioId(portid);
            foreach (Position p in posilist)
            {
                string isin = p.Isin;
                amountbefore += p.Quantity * p.Price;
                amountafter += p.Quantity * PriceHistoryDao.getLastPriceHistorysByisin(isin).OfferPrice;
            }
            pnl = Convert.ToDouble((amountafter - amountbefore) / amountbefore);
            return Ok(pnl);
        }

        [HttpGet]
        [Route("api/ALLPortfolios/{userid}")]
        public IHttpActionResult Getallportfolio(int userid)
        {
            List<Portfolio> portlist = PortfolioDao.getPortfoliosByUserId(userid);
            List<Portfilioandpnl> list = new List<Portfilioandpnl>();
            foreach(Portfolio p in portlist)
            {
                list.Add(new Portfilioandpnl(p.PortfolioId,p.Name,PortfolioHistoryDao.getLastPortfolioHistorysByPId(p.PortfolioId).PNL));
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
                //list.Add(new Portfilioandpnl(p.PortfolioId, p.Name, Portfilioandpnl.Caculatepnl(p.PortfolioId)));
                list.Add(new Portfilioandpnl(p.PortfolioId, p.Name, PortfolioHistoryDao.getLastPortfolioHistorysByPId(p.PortfolioId).PNL));
            }

            var query = from p in list
                        orderby p.PNL descending
                        select p;

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
    


            return Ok(list.Take(1));
        }



        [HttpGet]
        [Route("api/getPercentage/{portid}")]
        public IHttpActionResult GetPercentage(int portid)
        {

            List<Position> list = PositionDao.getPositionsByPortfolioId(portid);
            List<PositionPercentage> returnlist = new List<PositionPercentage>();
            var query = from p in list
                        orderby p.Price * p.Quantity
                        select p;

            foreach(Position p in query)
            {
                returnlist.Add(new PositionPercentage(p.Price * p.Quantity, StockDao.getStocksByIsin(p.Isin).Name));
            }


            return Ok(returnlist);
        }



        [HttpPost]
        [Route("api/UpdatePortfolios")]
        public IHttpActionResult updatePortfolioById(Portfolio c)
        {

            int changeLine = PortfolioDao.updatePortfolios(c);
            return Ok(c);
        }

        [HttpPost]
        [Route("api/addPortfolios")]
        public IHttpActionResult addPortfolios(Portfolio c)
        {
           
            int changeLine = PortfolioDao.addPortfolio(c);
            if(changeLine==1)
            {
                return Ok("Success");
            }
            return NotFound();
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
