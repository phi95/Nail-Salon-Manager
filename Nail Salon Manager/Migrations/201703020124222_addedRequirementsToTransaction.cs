namespace Nail_Salon_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRequirementsToTransaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Transactions", new[] { "EmployeeId" });
            AlterColumn("dbo.Transactions", "EmployeeId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Transactions", "EmployeeId");
            AddForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Transactions", new[] { "EmployeeId" });
            AlterColumn("dbo.Transactions", "EmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transactions", "EmployeeId");
            AddForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees", "Id");
        }
    }
}
