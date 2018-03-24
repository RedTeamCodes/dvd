namespace DVDStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DVDs", "Genre", c => c.String());
            AddColumn("dbo.DVDs", "Actor", c => c.String());
            AddColumn("dbo.DVDs", "Rating", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DVDs", "Rating");
            DropColumn("dbo.DVDs", "Actor");
            DropColumn("dbo.DVDs", "Genre");
        }
    }
}
