﻿using System;
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
    public class PortfolioHistoryController : ApiController
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
        [Route("api/OnePortfolioHistorys/{portid}")]
        public IHttpActionResult GetOnePortfolioHis(int portid)
        {
            List<PortfolioHistory> p = PortfolioHistoryDao.getPortfolioHistorysByPId(portid);
            List<double> pnl = new List<double>();
            List<string> time = new List<string>();
            foreach(PortfolioHistory record in p)
            {
                pnl.Add(record.PNL);
                time.Add(record.Date.ToString("D"));
            }

            return Ok(new OnePortfolioResult(time,pnl));

        }


        [HttpPost]
        [Route("api/addPortfolioHistorys")]
        public IHttpActionResult addPortfolioHistorys(PortfolioHistory c)
        {
            PortfolioHistory c1 = new PortfolioHistory { Id = 1, PortfolioId = 1, Date = Convert.ToDateTime("1992-03-20"), PNL = 0.387 };
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
