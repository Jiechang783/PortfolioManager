using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramwork.Entities;
using EntityFramwork.EntityDao;

namespace PortfolioManagerService.Models
{
    public class Portfilioandpnl
    {
        public int PortfolioID;
        public string PortfolioName;
        public double PNL;
        public Portfilioandpnl(int id,string name,double pnl)
        {
            this.PortfolioID = id;
            this.PortfolioName = name;
            this.PNL = pnl;
        }
        



    }
}