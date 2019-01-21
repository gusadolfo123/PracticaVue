namespace RepasoMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 80),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => new { t.ProductName, t.CategoryID }, unique: true);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerID, t.ProductID })
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "CustomerID" });
            DropIndex("dbo.Products", new[] { "ProductName", "CategoryID" });
            DropTable("dbo.Customers");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
