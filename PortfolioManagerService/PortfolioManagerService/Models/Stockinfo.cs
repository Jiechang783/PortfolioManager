using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManagerService.Models
{
    public class Securityinfo
    {
        public decimal Average;
        public decimal MaxPrice;
        public decimal MinPrice;
        public decimal Offer;
        public decimal Bid;

        public Securityinfo(decimal average,decimal maxium,decimal minium,decimal offer,decimal bid)
        {
            this.Average = average;
            this.MaxPrice = maxium;
            this.MinPrice = minium;
            this.Offer = offer;
            this.Bid = bid;
        }
    }
}