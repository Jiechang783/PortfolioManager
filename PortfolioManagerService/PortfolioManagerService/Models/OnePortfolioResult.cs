using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManagerService.Models
{
    public class OnePortfolioResult
    {
        
        public List<DateTime> time;
        public List<double> PNL;

        public OnePortfolioResult( List<DateTime> datetime,List<double> portpnl)
        {
            this.PNL = portpnl;
            this.time = datetime;
        }
    }
}