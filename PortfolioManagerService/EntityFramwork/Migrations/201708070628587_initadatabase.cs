namespace EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initadatabase : DbMigration
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
                        MaturityYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Isin);
            
            CreateTable(
                "dbo.Futures",
                c => new
                    {
                        ClrAlias = c.String(nullable: false, maxLength: 128),
                        Exch = c.String(),
                        Sym = c.String(),
                        Desc = c.String(),
                        SecTyp = c.String(),
                        MatDt = c.DateTime(nullable: false),
                        UOMQty = c.Long(nullable: false),
                        ID = c.String(),
                    })
                .PrimaryKey(t => t.ClrAlias);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        IndustryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IndustryId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Isin = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Symbol = c.String(nullable: false),
                        LastSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarketCap = c.String(),
                        IPOyear = c.DateTime(nullable: false),
                        SectorId = c.Int(nullable: false),
                        IndustryId = c.Int(nullable: false),
                        SummaryQuote = c.String(),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Isin)
                .ForeignKey("dbo.Industries", t => t.IndustryId, cascadeDelete: true)
                .ForeignKey("dbo.Sectors", t => t.SectorId, cascadeDelete: true)
                .Index(t => t.SectorId)
                .Index(t => t.IndustryId);
            
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PortfolioId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Isin = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        PortfolioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
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
                "dbo.Sectors",
                c => new
                    {
                        SectorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SectorId);
            
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
            DropForeignKey("dbo.Portfolios", "UserId", "dbo.Users");
            DropForeignKey("dbo.Stocks", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Positions", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Stocks", "IndustryId", "dbo.Industries");
            DropIndex("dbo.Positions", new[] { "PortfolioId" });
            DropIndex("dbo.Portfolios", new[] { "UserId" });
            DropIndex("dbo.Stocks", new[] { "IndustryId" });
            DropIndex("dbo.Stocks", new[] { "SectorId" });
            DropTable("dbo.Users");
            DropTable("dbo.Sectors");
            DropTable("dbo.PriceHistories");
            DropTable("dbo.Positions");
            DropTable("dbo.Portfolios");
            DropTable("dbo.PortfolioHistories");
            DropTable("dbo.Stocks");
            DropTable("dbo.Industries");
            DropTable("dbo.Futures");
            DropTable("dbo.Bonds");
        }
    }
}
