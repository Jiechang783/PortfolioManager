using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManagerService.Models
{
    public class Positionlist
    {
        public int PositionId;
        public string securityname;
        public int amount;
        public double pnl;
        public Positionlist(int id,string name,int amount,double pnl)
        {
            this.PositionId = id;
            this.securityname = name;
            this.pnl = pnl;
            this.amount = amount;
        }



    }
}