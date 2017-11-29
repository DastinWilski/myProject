namespace myProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pelna : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlaylistmyFiles", "Playlist_PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.PlaylistmyFiles", "myFile_FileId", "dbo.myFiles");
            DropIndex("dbo.PlaylistmyFiles", new[] { "Playlist_PlaylistId" });
            DropIndex("dbo.PlaylistmyFiles", new[] { "myFile_FileId" });
            CreateTable(
                "dbo.FilesToPlaylists",
                c => new
                    {
                        FilesToPlaylistID = c.Int(nullable: false, identity: true),
                        FileID = c.Int(nullable: false),
                        PlaylistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilesToPlaylistID)
                .ForeignKey("dbo.myFiles", t => t.FileID, cascadeDelete: true)
                .ForeignKey("dbo.Playlists", t => t.PlaylistID, cascadeDelete: true)
                .Index(t => t.FileID)
                .Index(t => t.PlaylistID);
            
            DropTable("dbo.PlaylistmyFiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlaylistmyFiles",
                c => new
                    {
                        Playlist_PlaylistId = c.Int(nullable: false),
                        myFile_FileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_PlaylistId, t.myFile_FileId });
            
            DropForeignKey("dbo.FilesToPlaylists", "PlaylistID", "dbo.Playlists");
            DropForeignKey("dbo.FilesToPlaylists", "FileID", "dbo.myFiles");
            DropIndex("dbo.FilesToPlaylists", new[] { "PlaylistID" });
            DropIndex("dbo.FilesToPlaylists", new[] { "FileID" });
            DropTable("dbo.FilesToPlaylists");
            CreateIndex("dbo.PlaylistmyFiles", "myFile_FileId");
            CreateIndex("dbo.PlaylistmyFiles", "Playlist_PlaylistId");
            AddForeignKey("dbo.PlaylistmyFiles", "myFile_FileId", "dbo.myFiles", "FileId", cascadeDelete: true);
            AddForeignKey("dbo.PlaylistmyFiles", "Playlist_PlaylistId", "dbo.Playlists", "PlaylistId", cascadeDelete: true);
        }
    }
}
