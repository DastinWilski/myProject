namespace myProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.myFiles",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        Created = c.DateTime(nullable: false),
                        Album_AlbumId = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId)
                .Index(t => t.Album_AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.myFiles", "Album_AlbumId", "dbo.Albums");
            DropIndex("dbo.myFiles", new[] { "Album_AlbumId" });
            DropTable("dbo.myFiles");
            DropTable("dbo.Albums");
        }
    }
}
