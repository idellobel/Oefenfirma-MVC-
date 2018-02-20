namespace Ivo.OefenfirmaCMS.lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbrole : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoleUsers", newName: "UserRoles");
            DropPrimaryKey("dbo.UserRoles");
            AddPrimaryKey("dbo.UserRoles", new[] { "User_Id", "Role_RoleId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserRoles");
            AddPrimaryKey("dbo.UserRoles", new[] { "Role_RoleId", "User_Id" });
            RenameTable(name: "dbo.UserRoles", newName: "RoleUsers");
        }
    }
}
