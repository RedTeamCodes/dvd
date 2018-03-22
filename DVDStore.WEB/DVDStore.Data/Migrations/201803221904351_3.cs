namespace DVDStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DVDs", "ActorID", "dbo.Actors");
            DropIndex("dbo.DVDs", new[] { "ActorID" });
            DropPrimaryKey("dbo.SalesInfoes");
            CreateTable(
                "dbo.DVDActors",
                c => new
                    {
                        DVD_Id = c.Int(nullable: false),
                        Actor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DVD_Id, t.Actor_Id })
                .ForeignKey("dbo.DVDs", t => t.DVD_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .Index(t => t.DVD_Id)
                .Index(t => t.Actor_Id);
            
            AddColumn("dbo.DVDs", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DVDs", "GenresID_Id", c => c.Int());
            AddColumn("dbo.DVDs", "RatingsID_Id", c => c.Int());
            AlterColumn("dbo.SalesInfoes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesInfoes", "Sold", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.SalesInfoes", "Id");
            CreateIndex("dbo.DVDs", "GenresID_Id");
            CreateIndex("dbo.DVDs", "RatingsID_Id");
            CreateIndex("dbo.SalesInfoes", "Id");
            AddForeignKey("dbo.DVDs", "GenresID_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.DVDs", "RatingsID_Id", "dbo.Ratings", "Id");
            AddForeignKey("dbo.SalesInfoes", "Id", "dbo.DVDs", "Id");
            DropColumn("dbo.DVDs", "Year");
            DropColumn("dbo.DVDs", "ActorID");
            DropColumn("dbo.DVDs", "RatingsID");
            DropColumn("dbo.DVDs", "GenresID");
            DropColumn("dbo.DVDs", "SalesInfoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DVDs", "SalesInfoID", c => c.Int(nullable: false));
            AddColumn("dbo.DVDs", "GenresID", c => c.Int(nullable: false));
            AddColumn("dbo.DVDs", "RatingsID", c => c.Int(nullable: false));
            AddColumn("dbo.DVDs", "ActorID", c => c.Int(nullable: false));
            AddColumn("dbo.DVDs", "Year", c => c.Int(nullable: false));
            DropForeignKey("dbo.SalesInfoes", "Id", "dbo.DVDs");
            DropForeignKey("dbo.DVDs", "RatingsID_Id", "dbo.Ratings");
            DropForeignKey("dbo.DVDs", "GenresID_Id", "dbo.Genres");
            DropForeignKey("dbo.DVDActors", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.DVDActors", "DVD_Id", "dbo.DVDs");
            DropIndex("dbo.DVDActors", new[] { "Actor_Id" });
            DropIndex("dbo.DVDActors", new[] { "DVD_Id" });
            DropIndex("dbo.SalesInfoes", new[] { "Id" });
            DropIndex("dbo.DVDs", new[] { "RatingsID_Id" });
            DropIndex("dbo.DVDs", new[] { "GenresID_Id" });
            DropPrimaryKey("dbo.SalesInfoes");
            AlterColumn("dbo.SalesInfoes", "Sold", c => c.String(nullable: false));
            AlterColumn("dbo.SalesInfoes", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.DVDs", "RatingsID_Id");
            DropColumn("dbo.DVDs", "GenresID_Id");
            DropColumn("dbo.DVDs", "ReleaseDate");
            DropTable("dbo.DVDActors");
            AddPrimaryKey("dbo.SalesInfoes", "Id");
            CreateIndex("dbo.DVDs", "ActorID");
            AddForeignKey("dbo.DVDs", "ActorID", "dbo.Actors", "Id", cascadeDelete: true);
        }
    }
}
