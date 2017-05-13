namespace SuperStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        CusomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        Title = c.String(maxLength: 50),
                        Price = c.Int(nullable: false),
                        Employee_ID = c.Int(),
                        Employee_ID1 = c.Int(),
                        Employee_ID2 = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID1)
                .ForeignKey("dbo.Employees", t => t.Employee_ID2)
                .Index(t => t.Employee_ID)
                .Index(t => t.Employee_ID1)
                .Index(t => t.Employee_ID2);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Employees", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "Employee_ID2", "dbo.Employees");
            DropForeignKey("dbo.Products", "Employee_ID1", "dbo.Employees");
            DropForeignKey("dbo.Products", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.Purchases", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Employees", new[] { "Product_ProductID" });
            DropIndex("dbo.Products", new[] { "Employee_ID2" });
            DropIndex("dbo.Products", new[] { "Employee_ID1" });
            DropIndex("dbo.Products", new[] { "Employee_ID" });
            DropIndex("dbo.Purchases", new[] { "CustomerID" });
            DropIndex("dbo.Purchases", new[] { "ProductID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Products");
            DropTable("dbo.Purchases");
            DropTable("dbo.Customers");
        }
    }
}
