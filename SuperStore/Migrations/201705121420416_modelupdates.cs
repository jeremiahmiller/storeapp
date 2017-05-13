namespace SuperStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelupdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.Products", "Employee_ID1", "dbo.Employees");
            DropForeignKey("dbo.Products", "Employee_ID2", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Purchases", "ProductID", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Employee_ID" });
            DropIndex("dbo.Products", new[] { "Employee_ID1" });
            DropIndex("dbo.Products", new[] { "Employee_ID2" });
            DropIndex("dbo.Employees", new[] { "Product_ProductID" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "ProductID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.Products", "ProductID");
            AddForeignKey("dbo.Purchases", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            DropColumn("dbo.Purchases", "CusomerID");
            DropColumn("dbo.Products", "Employee_ID");
            DropColumn("dbo.Products", "Employee_ID1");
            DropColumn("dbo.Products", "Employee_ID2");
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "Employee_ID2", c => c.Int());
            AddColumn("dbo.Products", "Employee_ID1", c => c.Int());
            AddColumn("dbo.Products", "Employee_ID", c => c.Int());
            AddColumn("dbo.Purchases", "CusomerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Purchases", "ProductID", "dbo.Products");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Products", "ProductID");
            CreateIndex("dbo.Employees", "Product_ProductID");
            CreateIndex("dbo.Products", "Employee_ID2");
            CreateIndex("dbo.Products", "Employee_ID1");
            CreateIndex("dbo.Products", "Employee_ID");
            AddForeignKey("dbo.Purchases", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Product_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.Products", "Employee_ID2", "dbo.Employees", "ID");
            AddForeignKey("dbo.Products", "Employee_ID1", "dbo.Employees", "ID");
            AddForeignKey("dbo.Products", "Employee_ID", "dbo.Employees", "ID");
        }
    }
}
