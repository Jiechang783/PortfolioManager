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
        public string PNL;
        public string isin;
        public decimal Bid;
        public decimal Offer;
        public string Type;
        public Positionlist(int id,string name,decimal bid,int amount,decimal offerprice,string pnl,string type,string isin)
        {
            this.PositionId = id;
            this.SecurityName = name;
            this.Bid = bid;
            this.Offer = offerprice;
            this.PNL = pnl;
            this.Quantity = amount;
            this.Type = type;
            this.isin = isin;
            
        }



    }
}