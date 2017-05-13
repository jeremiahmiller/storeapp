namespace SuperStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedcustomerstuff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Age");
            DropColumn("dbo.Customers", "Salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Salary", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
        }
    }
}
