namespace TravelExpress5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trajets", "Prix", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trajets", "Prix");
        }
    }
}
