namespace TravelExpress5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrefFumeur = c.Boolean(nullable: false),
                        PrefAnimaux = c.Boolean(nullable: false),
                        PrefDiscussion = c.Boolean(nullable: false),
                        PrefMusique = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Preferences_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Preferences_Id");
            AddForeignKey("dbo.AspNetUsers", "Preferences_Id", "dbo.Preferences", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Preferences_Id", "dbo.Preferences");
            DropIndex("dbo.AspNetUsers", new[] { "Preferences_Id" });
            DropColumn("dbo.AspNetUsers", "Preferences_Id");
            DropTable("dbo.Preferences");
        }
    }
}
