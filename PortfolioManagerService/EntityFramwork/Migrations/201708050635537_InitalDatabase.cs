namespace EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDatabase : DbMigration
    {
        public override void Up()
        {
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
                        Isin = c.String(nullable: false, maxLength: 128),
                        Portfolio_PortfolioId = c.Int(),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Securities", t => t.Isin, cascadeDelete: true)
                .ForeignKey("dbo.Portfolios", t => t.Portfolio_PortfolioId)
                .Index(t => t.Isin)
                .Index(t => t.Portfolio_PortfolioId);
            
            CreateTable(
                "dbo.Securities",
                c => new
                    {
                        Isin = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Isin);
            
            CreateTable(
                "dbo.PriceHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isin = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Positions", "Isin", "dbo.Securities");
            DropIndex("dbo.Positions", new[] { "Portfolio_PortfolioId" });
            DropIndex("dbo.Positions", new[] { "Isin" });
            DropIndex("dbo.Portfolios", new[] { "User_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.PriceHistories");
            DropTable("dbo.Securities");
            DropTable("dbo.Positions");
            DropTable("dbo.Portfolios");
            DropTable("dbo.PortfolioHistories");
        }
    }
}
