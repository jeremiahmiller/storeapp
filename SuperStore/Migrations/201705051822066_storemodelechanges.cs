namespace SuperStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storemodelechanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchase", "ProductID", "dbo.Product");
            DropPrimaryKey("dbo.Product");
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductEmployee",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.EmployeeID })
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.EmployeeID);
            
            AddColumn("dbo.Product", "DepartmentID", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Employee_ID", c => c.Int());
            AddColumn("dbo.Product", "Employee_ID1", c => c.Int());
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Product", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Title", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Product", "ProductID");
            CreateIndex("dbo.Product", "Employee_ID");
            CreateIndex("dbo.Product", "Employee_ID1");
            AddForeignKey("dbo.Product", "Employee_ID", "dbo.Employee", "ID");
            AddForeignKey("dbo.Product", "Employee_ID1", "dbo.Employee", "ID");
            AddForeignKey("dbo.Purchase", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            DropColumn("dbo.Product", "ProductName");
            DropColumn("dbo.Product", "UPC");
            DropColumn("dbo.Product", "Inventory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Inventory", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "UPC", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "ProductName", c => c.String());
            DropForeignKey("dbo.Purchase", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductEmployee", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.ProductEmployee", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "Employee_ID1", "dbo.Employee");
            DropForeignKey("dbo.Product", "Employee_ID", "dbo.Employee");
            DropIndex("dbo.ProductEmployee", new[] { "EmployeeID" });
            DropIndex("dbo.ProductEmployee", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "Employee_ID1" });
            DropIndex("dbo.Product", new[] { "Employee_ID" });
            DropPrimaryKey("dbo.Product");
            AlterColumn("dbo.Product", "Title", c => c.String());
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "ProductID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customer", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(maxLength: 50));
            DropColumn("dbo.Product", "Employee_ID1");
            DropColumn("dbo.Product", "Employee_ID");
            DropColumn("dbo.Product", "DepartmentID");
            DropTable("dbo.ProductEmployee");
            DropTable("dbo.Employee");
            AddPrimaryKey("dbo.Product", "ProductID");
            AddForeignKey("dbo.Purchase", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
    }
}
