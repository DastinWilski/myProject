namespace myProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdone : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.myFiles", newName: "Files");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Files", newName: "myFiles");
        }
    }
}
