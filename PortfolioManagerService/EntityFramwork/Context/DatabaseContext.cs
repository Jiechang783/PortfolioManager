using EntityFramwork.Entities;
using System.Data.Entity;

namespace EntityFramwork.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Portfolio> Portfolios { get; set; }

        public virtual IDbSet<PortfolioHistory> PortfolioHistories { get; set; }

        public virtual IDbSet<PriceHistory> PriceHistorys { get; set; }

        public virtual IDbSet<Stock> Stocks { get; set; }

        public virtual IDbSet<Bond> Bonds { get; set; }

        public virtual IDbSet<Future> Futures { get; set; }

        public virtual IDbSet<Sector> Sectors { get; set; }

        public virtual IDbSet<Industry> Industrys { get; set; }
        public virtual IDbSet<Position> Positions { get; set; }
    }
}
