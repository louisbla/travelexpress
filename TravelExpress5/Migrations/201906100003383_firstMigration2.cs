namespace TravelExpress5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trajets", "VilleDepart", c => c.String());
            AddColumn("dbo.Trajets", "VilleArrivee", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trajets", "VilleArrivee");
            DropColumn("dbo.Trajets", "VilleDepart");
        }
    }
}
