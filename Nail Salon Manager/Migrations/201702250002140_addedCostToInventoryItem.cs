namespace Nail_Salon_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCostToInventoryItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryItems", "Cost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InventoryItems", "Cost");
        }
    }
}
