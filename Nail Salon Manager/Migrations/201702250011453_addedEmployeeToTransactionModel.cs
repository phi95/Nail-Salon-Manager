namespace Nail_Salon_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEmployeeToTransactionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Transactions", new[] { "Employee_Id" });
            RenameColumn(table: "dbo.Transactions", name: "Employee_Id", newName: "EmployeeId");
            AlterColumn("dbo.Transactions", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "EmployeeId");
            AddForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Transactions", new[] { "EmployeeId" });
            AlterColumn("dbo.Transactions", "EmployeeId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "EmployeeId", newName: "Employee_Id");
            CreateIndex("dbo.Transactions", "Employee_Id");
            AddForeignKey("dbo.Transactions", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
