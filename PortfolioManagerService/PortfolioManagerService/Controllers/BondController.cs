﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityFramwork.Entities;
using EntityFramwork.EntityDao;

namespace PortfolioManagerService.Controllers
{
    public class BondController : ApiController
    {
        [HttpGet]
        [Route("api/Bonds")]
        public IHttpActionResult Get()
        {
            return Ok(BondsDao.getBonds());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Bondss/{id}")]
        public IHttpActionResult Get(int id)
        {
            Bond p = BondsDao.getBondById(id);
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
        public IHttpActionResult updateBondsById(Bond c)
        {

            int changeLine = BondsDao.updateBond(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addBondss")]
        public IHttpActionResult addBondss(Bond c)
        {

            int changeLine = BondsDao.addBond(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deleteBondss")]
        public IHttpActionResult deleteBondss(Bond c)
        {
            
            int changeLine = BondsDao.deleteBond(c);
            return Ok(changeLine);
        }
    }
}
