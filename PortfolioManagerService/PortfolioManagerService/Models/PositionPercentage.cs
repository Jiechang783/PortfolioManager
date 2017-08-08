using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManagerService.Models
{
    public class PositionPercentage
    {
        public decimal value;
        public string name;
        public PositionPercentage(decimal value,string stockname)
        {
            this.value = value;
            this.name = stockname;
        }
    }
}