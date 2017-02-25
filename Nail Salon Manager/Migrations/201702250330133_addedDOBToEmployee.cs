namespace Nail_Salon_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDOBToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "DOB");
        }
    }
}
