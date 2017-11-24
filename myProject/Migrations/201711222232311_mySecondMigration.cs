namespace myProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mySecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.myFiles", "Album_AlbumId", "dbo.Albums");
            DropIndex("dbo.myFiles", new[] { "Album_AlbumId" });
            RenameColumn(table: "dbo.myFiles", name: "Album_AlbumId", newName: "AlbumID");
            AlterColumn("dbo.myFiles", "AlbumID", c => c.Int(nullable: false));
            CreateIndex("dbo.myFiles", "AlbumID");
            AddForeignKey("dbo.myFiles", "AlbumID", "dbo.Albums", "AlbumId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.myFiles", "AlbumID", "dbo.Albums");
            DropIndex("dbo.myFiles", new[] { "AlbumID" });
            AlterColumn("dbo.myFiles", "AlbumID", c => c.Int());
            RenameColumn(table: "dbo.myFiles", name: "AlbumID", newName: "Album_AlbumId");
            CreateIndex("dbo.myFiles", "Album_AlbumId");
            AddForeignKey("dbo.myFiles", "Album_AlbumId", "dbo.Albums", "AlbumId");
        }
    }
}
