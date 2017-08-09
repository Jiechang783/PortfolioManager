using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorWervice.Models
{
    public class Portfolioandpnl
    {
        public int PortfolioID;
        public string PortfolioName;
        public string ManagerName;
        public double PNL;
        public Portfolioandpnl(int id,string pname,string mname,double pnl)
        {
            this.PortfolioID = id;
            this.ManagerName = mname;
            this.PortfolioName = pname;
            this.PNL = pnl;
        }
        
    }
}