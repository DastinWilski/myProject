namespace myProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Files", newName: "myFiles");
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.myTypes",
                c => new
                    {
                        myTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.myTypeId);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
            CreateTable(
                "dbo.PlaylistmyFiles",
                c => new
                    {
                        Playlist_PlaylistId = c.Int(nullable: false),
                        myFile_FileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_PlaylistId, t.myFile_FileId })
                .ForeignKey("dbo.Playlists", t => t.Playlist_PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.myFiles", t => t.myFile_FileId, cascadeDelete: true)
                .Index(t => t.Playlist_PlaylistId)
                .Index(t => t.myFile_FileId);
            
            AddColumn("dbo.myFiles", "GenreID", c => c.Int(nullable: false));
            AddColumn("dbo.myFiles", "myTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.myFiles", "GenreID");
            CreateIndex("dbo.myFiles", "myTypeID");
            AddForeignKey("dbo.myFiles", "GenreID", "dbo.Genres", "GenreId", cascadeDelete: true);
            AddForeignKey("dbo.myFiles", "myTypeID", "dbo.myTypes", "myTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistmyFiles", "myFile_FileId", "dbo.myFiles");
            DropForeignKey("dbo.PlaylistmyFiles", "Playlist_PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.myFiles", "myTypeID", "dbo.myTypes");
            DropForeignKey("dbo.myFiles", "GenreID", "dbo.Genres");
            DropIndex("dbo.PlaylistmyFiles", new[] { "myFile_FileId" });
            DropIndex("dbo.PlaylistmyFiles", new[] { "Playlist_PlaylistId" });
            DropIndex("dbo.myFiles", new[] { "myTypeID" });
            DropIndex("dbo.myFiles", new[] { "GenreID" });
            DropColumn("dbo.myFiles", "myTypeID");
            DropColumn("dbo.myFiles", "GenreID");
            DropTable("dbo.PlaylistmyFiles");
            DropTable("dbo.Playlists");
            DropTable("dbo.myTypes");
            DropTable("dbo.Genres");
            RenameTable(name: "dbo.myFiles", newName: "Files");
        }
    }
}
