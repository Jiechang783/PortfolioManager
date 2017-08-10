using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManagerService.Models
{
    public class OnePortfolioResult
    {
        
        public List<string> time;
        public List<double> PNL;

        public OnePortfolioResult( List<string> datetime,List<double> portpnl)
        {
            this.PNL = portpnl;
            this.time = datetime;
        }
    }
}