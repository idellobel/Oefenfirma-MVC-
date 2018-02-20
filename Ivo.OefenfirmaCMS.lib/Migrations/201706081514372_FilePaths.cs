namespace Ivo.OefenfirmaCMS.lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePaths : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Files", newName: "FilePaths");
            AlterColumn("dbo.Products", "Prijs", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Prijs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            RenameTable(name: "dbo.FilePaths", newName: "Files");
        }
    }
}
