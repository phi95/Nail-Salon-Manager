namespace Nail_Salon_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedEmployeeIdToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.InventoryItems", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Employer_Id" });
            DropIndex("dbo.Transactions", new[] { "EmployeeId" });
            DropIndex("dbo.InventoryItems", new[] { "Employer_Id" });
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "Id");
            AddColumn("dbo.Employees", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Transactions", "EmployeeId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.Transactions", "EmployeeId");
            AddForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees", "Id");
            DropColumn("dbo.Employees", "Employer_Id");
            DropColumn("dbo.InventoryItems", "Employer_Id");
            DropTable("dbo.Employers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.InventoryItems", "Employer_Id", c => c.Int());
            AddColumn("dbo.Employees", "Employer_Id", c => c.Int());
            DropForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Transactions", new[] { "EmployeeId" });
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Transactions", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.InventoryItems", "Employer_Id");
            CreateIndex("dbo.Transactions", "EmployeeId");
            CreateIndex("dbo.Employees", "Employer_Id");
            AddForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InventoryItems", "Employer_Id", "dbo.Employers", "Id");
            AddForeignKey("dbo.Employees", "Employer_Id", "dbo.Employers", "Id");
        }
    }
}
