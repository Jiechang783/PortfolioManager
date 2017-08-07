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
    public class PositionController : ApiController
    {
        [HttpGet]
        [Route("api/Position")]
        public IHttpActionResult Get()
        {
            return Ok(PositionDao.getPositions());
        }

        [HttpGet]
        // GET api/values/5
        [Route("api/Positions/{id}")]
        public IHttpActionResult Get(int id)
        {
            Position p = PositionDao.getPositionsById(id);
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
        [Route("api/UpdatePositions")]
        public IHttpActionResult updatePositionById(Position c)
        {
            Position c1 = new Position { PositionId=1, Quantity=12, Price=21, Isin=1,Type="not"};
            int changeLine = PositionDao.updatePositions(c1);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addPositions")]
        public IHttpActionResult addPositions(Position c)
        {

            int changeLine = PositionDao.setPosition(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/deletePositions")]
        public IHttpActionResult deletePositions(Position c)
        {
            //  Position c1 = new Position(Convert.ToInt32(d),"ztt", "ztt", 0, "1975-06-04 00:00:00.000");
            int changeLine = PositionDao.deletePositions(c);
            return Ok(changeLine);
        }
    }
}
