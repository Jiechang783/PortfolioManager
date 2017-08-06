namespace EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initadatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "Isin", "dbo.Securities");
            DropIndex("dbo.Positions", new[] { "Isin" });
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
            
            AddColumn("dbo.Positions", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Positions", "Isin", c => c.Int(nullable: false));
            AlterColumn("dbo.PriceHistories", "Isin", c => c.Int(nullable: false));
            DropTable("dbo.Securities");
        }
        
        public override void Down()
        {
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
            
            AlterColumn("dbo.PriceHistories", "Isin", c => c.String(nullable: false));
            AlterColumn("dbo.Positions", "Isin", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Positions", "Type");
            DropTable("dbo.Stocks");
            DropTable("dbo.Bonds");
            CreateIndex("dbo.Positions", "Isin");
            AddForeignKey("dbo.Positions", "Isin", "dbo.Securities", "Isin", cascadeDelete: true);
        }
    }
}
