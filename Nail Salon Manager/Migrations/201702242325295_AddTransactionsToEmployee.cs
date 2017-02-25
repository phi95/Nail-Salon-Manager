namespace Nail_Salon_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionsToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Employee_Id", c => c.Int());
            CreateIndex("dbo.Transactions", "Employee_Id");
            AddForeignKey("dbo.Transactions", "Employee_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Transactions", new[] { "Employee_Id" });
            DropColumn("dbo.Transactions", "Employee_Id");
        }
    }
}
