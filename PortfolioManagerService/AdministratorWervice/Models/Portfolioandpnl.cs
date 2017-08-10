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
        public string PNL;
        public Portfolioandpnl(int id,string pname,string mname,string pnl)
        {
            this.PortfolioID = id;
            this.ManagerName = mname;
            this.PortfolioName = pname;
            this.PNL = pnl;
        }
        
    }
}