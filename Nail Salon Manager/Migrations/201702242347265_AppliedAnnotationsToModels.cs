namespace Nail_Salon_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppliedAnnotationsToModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Employers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.InventoryItems", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InventoryItems", "Name", c => c.String());
            AlterColumn("dbo.Employers", "Name", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
