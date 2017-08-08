using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManagerService.Models
{
    public class OneStockresult
    {
        public List<DateTime> time;
        public List<Decimal> price;

        public OneStockresult(List<DateTime> datatime,List<Decimal> stockprice)
        {
            this.time = datatime;
            this.price = stockprice;
        }
    }
}