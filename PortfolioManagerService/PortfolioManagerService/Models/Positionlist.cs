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
        public Positionlist(int id,string name,int amount,double pnl)
        {
            this.PositionId = id;
            this.SecurityName = name;
            this.PNL = pnl;
            this.Quantity = amount;
        }



    }
}