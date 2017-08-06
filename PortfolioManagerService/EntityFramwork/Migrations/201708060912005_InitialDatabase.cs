namespace EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bonds",
                c => new
                    {
                        Isin = c.Int(nullable: false, identity: true),
                        Issuer = c.String(nullable: false),
                        Coupon = c.Double(nullable: false),
                        MaturityMonth = c.String(nullable: false),
                        MaturityYear = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Isin);
            
            CreateTable(
                "dbo.PortfolioHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PortfolioId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PNL = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PortfolioId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Isin = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Portfolio_PortfolioId = c.Int(),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Portfolios", t => t.Portfolio_PortfolioId)
                .Index(t => t.Portfolio_PortfolioId);
            
            CreateTable(
                "dbo.PriceHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isin = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Isin = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Symbol = c.String(nullable: false),
                        LastSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarketCap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IPOyear = c.DateTime(nullable: false),
                        Sector = c.String(nullable: false),
                        industry = c.String(nullable: false),
                        SummaryQuote = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Isin);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        telephone = c.String(),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Portfolios", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Positions", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Positions", new[] { "Portfolio_PortfolioId" });
            DropIndex("dbo.Portfolios", new[] { "User_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Stocks");
            DropTable("dbo.PriceHistories");
            DropTable("dbo.Positions");
            DropTable("dbo.Portfolios");
            DropTable("dbo.PortfolioHistories");
            DropTable("dbo.Bonds");
        }
    }
}
