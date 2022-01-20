namespace Game_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseDate = c.String(),
                        Publisher = c.String(),
                        ESRBRating = c.Int(nullable: false),
                        StarRating = c.Double(nullable: false),
                        GenreId = c.Int(nullable: false),
                        GameSystemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.GameSystems", t => t.GameSystemId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.GameSystemId);
            
            CreateTable(
                "dbo.GameSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Games", "GameSystemId", "dbo.GameSystems");
            DropIndex("dbo.Games", new[] { "GameSystemId" });
            DropIndex("dbo.Games", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.GameSystems");
            DropTable("dbo.Games");
        }
    }
}
