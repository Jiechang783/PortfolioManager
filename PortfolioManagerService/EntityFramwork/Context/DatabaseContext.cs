using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Context
{
   public class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {
        }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Portfolio> Portfolios { get; set; }

        public virtual IDbSet<PortfolioHistory> PortfolioHistories { get; set; }

        public virtual IDbSet<PriceHistory> PriceHistorys { get; set; }

        public virtual IDbSet<Stock> Stocks { get; set; }

        public virtual IDbSet<Bonds> Bondses { get; set; }
        public virtual IDbSet<Position> Positions { get; set; }
    }
}
