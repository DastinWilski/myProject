namespace myProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixith : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "AlbumName", c => c.String());
            AddColumn("dbo.myFiles", "FileName", c => c.String());
            AddColumn("dbo.Genres", "GenreName", c => c.String());
            AddColumn("dbo.myTypes", "TypeName", c => c.String());
            AddColumn("dbo.Playlists", "PlaylistName", c => c.String());
            DropColumn("dbo.Albums", "Name");
            DropColumn("dbo.myFiles", "Name");
            DropColumn("dbo.Genres", "Name");
            DropColumn("dbo.myTypes", "Name");
            DropColumn("dbo.Playlists", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playlists", "Name", c => c.String());
            AddColumn("dbo.myTypes", "Name", c => c.String());
            AddColumn("dbo.Genres", "Name", c => c.String());
            AddColumn("dbo.myFiles", "Name", c => c.String());
            AddColumn("dbo.Albums", "Name", c => c.String());
            DropColumn("dbo.Playlists", "PlaylistName");
            DropColumn("dbo.myTypes", "TypeName");
            DropColumn("dbo.Genres", "GenreName");
            DropColumn("dbo.myFiles", "FileName");
            DropColumn("dbo.Albums", "AlbumName");
        }
    }
}
