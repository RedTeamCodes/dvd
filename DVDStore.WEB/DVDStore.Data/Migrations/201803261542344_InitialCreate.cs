namespace DVDStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Middle = c.String(),
                        Last = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.String(),
                        Actor = c.String(),
                        Rating = c.String(),
                        Description = c.String(),
                        PictureSmall = c.Binary(),
                        GenresID_Id = c.Int(),
                        RatingsID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenresID_Id)
                .ForeignKey("dbo.Ratings", t => t.RatingsID_Id)
                .Index(t => t.GenresID_Id)
                .Index(t => t.RatingsID_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Sold = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DVDs", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ActorsinMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActorID = c.Int(nullable: false),
                        DVDID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
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
            DropTable("dbo.DVDActors");
            DropTable("dbo.ActorsinMovies");
            DropTable("dbo.SalesInfoes");
            DropTable("dbo.Ratings");
            DropTable("dbo.Genres");
            DropTable("dbo.DVDs");
            DropTable("dbo.Actors");
        }
    }
}
