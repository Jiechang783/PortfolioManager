using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManagerService.Models
{
    public class Positionlist
    {
        public int PositionId;
        public string SecurityName;
        public int Quantity;
        public double PNL;
        public decimal Bid;
        public decimal Offer;
        public Positionlist(int id,string name,decimal bid,int amount,decimal offerprice,double pnl)
        {
            this.PositionId = id;
            this.SecurityName = name;
            this.Bid = bid;
            this.Offer = offerprice;
            this.PNL = pnl;
            this.Quantity = amount;
            
        }



    }
}