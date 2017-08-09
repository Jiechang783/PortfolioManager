using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorWervice.Models
{
    public class Portfolioinfo
    {
        public int PortfolioID;
        public string PortfolioName;
        public string ManagerName;
        public double PNL;

        public Portfolioinfo(int id,string pname,string mname,double pnl)
        {
            this.PortfolioID = id;
            this.PortfolioName = pname;
            this.ManagerName = mname;
            this.PNL = pnl;
        }



    }
}