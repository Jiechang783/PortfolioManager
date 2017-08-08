using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManagerService.Models
{
    public class Securityinfo
    {
        public decimal avg;
        public decimal max;
        public decimal min;

        public Securityinfo(decimal average,decimal maxium,decimal minium)
        {
            this.avg = average;
            this.max = maxium;
            this.min = minium;
        }
    }
}