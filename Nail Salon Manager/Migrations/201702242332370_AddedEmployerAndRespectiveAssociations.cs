namespace Nail_Salon_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployerAndRespectiveAssociations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "Employer_Id", c => c.Int());
            AddColumn("dbo.InventoryItems", "Employer_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Employer_Id");
            CreateIndex("dbo.InventoryItems", "Employer_Id");
            AddForeignKey("dbo.Employees", "Employer_Id", "dbo.Employers", "Id");
            AddForeignKey("dbo.InventoryItems", "Employer_Id", "dbo.Employers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryItems", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.Employees", "Employer_Id", "dbo.Employers");
            DropIndex("dbo.InventoryItems", new[] { "Employer_Id" });
            DropIndex("dbo.Employees", new[] { "Employer_Id" });
            DropColumn("dbo.InventoryItems", "Employer_Id");
            DropColumn("dbo.Employees", "Employer_Id");
            DropTable("dbo.Employers");
        }
    }
}
