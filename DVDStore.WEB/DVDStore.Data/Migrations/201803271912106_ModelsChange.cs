namespace DVDStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "First", c => c.String(nullable: false));
            DropColumn("dbo.Actors", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actors", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Actors", "First");
        }
    }
}
