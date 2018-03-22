namespace DVDStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.ActorsinMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActorID = c.Int(nullable: false),
                        DVDID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActorID = c.Int(nullable: false),
                        RatingsID = c.Int(nullable: false),
                        GenresID = c.Int(nullable: false),
                        SalesInfoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorID, cascadeDelete: true)
                .Index(t => t.ActorID);
            
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
                        Id = c.Int(nullable: false, identity: true),
                        Sold = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DVDs", "ActorID", "dbo.Actors");
            DropIndex("dbo.DVDs", new[] { "ActorID" });
            DropTable("dbo.SalesInfoes");
            DropTable("dbo.Ratings");
            DropTable("dbo.Genres");
            DropTable("dbo.DVDs");
            DropTable("dbo.ActorsinMovies");
            DropTable("dbo.Actors");
        }
    }
}
