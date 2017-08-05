using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Context
{
   public class DatabaseContext:DbContext
    {
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Portfolio> Portfolios { get; set; }

        public virtual IDbSet<PortfolioHistory> OrdPortfolioHistories { get; set; }

        public virtual IDbSet<PriceHistory> PriceHistorys { get; set; }

        public virtual IDbSet<Security> Securitys { get; set; }

        public virtual IDbSet<Position> Positions { get; set; }
    }
}
