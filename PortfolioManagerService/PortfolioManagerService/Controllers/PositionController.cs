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



        [HttpGet]
        [Route("api/PositionbypoID/{portfolioid}")]
        public IHttpActionResult GetPositionsbyPortID(int portfolioid)
        {
            List<Position> positionlist = PositionDao.getPositionsByPortfolioId(portfolioid);
            List<Positionlist> returnlist = new List<Positionlist>();
            foreach(Position p in positionlist)
            {
                double porfit = 0;
                porfit = Convert.ToDouble((PriceHistoryDao.getLastPriceHistorysByisin(p.Isin).OfferPrice - p.Price) / p.Price);
                returnlist.Add(new Positionlist(p.PositionId, StockDao.getStocksByIsin(p.Isin).Name,p.Price, p.Quantity, PriceHistoryDao.getLastPriceHistorysByisin(p.Isin).OfferPrice, porfit));
          
            }
            
            return Ok(returnlist);
        }



        [HttpPost]
        [Route("api/UpdatePositions")]
        public IHttpActionResult updatePositionById(Position c)
        {
            int changeLine = PositionDao.updatePositions(c);
            return Ok(changeLine);
        }

        [HttpPost]
        [Route("api/addPositions")]
        public IHttpActionResult addPositions(dynamic c)
        {
            Portfolio p = PortfolioDao.getPortfolioBySomething(new Portfolio { Name = c.Name, UserId = c.UserId });
            Position position = new Position();
            position.Isin = c.Isin;
            position.PortfolioId = p.PortfolioId;
            position.Price = PriceHistoryDao.getLastPriceHistorysByisin(position.Isin).BidPrice;
            position.Quantity = c.Quantity;
            position.Type = c.Type;

            int changeLine = PositionDao.setPosition(c);
            return Ok(changeLine);
        }

        [HttpGet]
        [Route("api/deletePositions")]
        public IHttpActionResult deletePositions(Position c)
        {
            //  Position c1 = new Position(Convert.ToInt32(d),"ztt", "ztt", 0, "1975-06-04 00:00:00.000");
            int changeLine = PositionDao.deletePositions(c);
            return Ok(changeLine);
        }
    }
}
