namespace Ivo.OefenfirmaCMS.lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gebruikers",
                c => new
                    {
                        GebruikerId = c.Guid(nullable: false),
                        Email = c.String(nullable: false),
                        Familienaam = c.String(nullable: false, maxLength: 50),
                        Voornaam = c.String(nullable: false, maxLength: 50),
                        Adres = c.String(nullable: false, maxLength: 70),
                        Postcode = c.Int(nullable: false),
                        Gemeente = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GebruikerId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categorienaam = c.String(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Artikelnummer = c.String(nullable: false, maxLength: 20),
                        Artikelnaam = c.String(nullable: false, maxLength: 512),
                        Artikelomschrijving = c.String(nullable: false),
                        Prijs = c.Decimal(nullable: false, storeType: "money"),
                        FiguurURL = c.String(maxLength: 512),
                        Spotlight = c.Boolean(nullable: false),
                        Categorie_Id = c.Int(),
                        Leverancier_GebruikerId = c.Guid(),
                    })
                .PrimaryKey(t => t.Artikelnummer)
                .ForeignKey("dbo.Categories", t => t.Categorie_Id)
                .ForeignKey("dbo.Leverancier", t => t.Leverancier_GebruikerId)
                .Index(t => t.Categorie_Id)
                .Index(t => t.Leverancier_GebruikerId);
            
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        Artikelnummer = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Products", t => t.Artikelnummer)
                .Index(t => t.Artikelnummer);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Gebruikersnaam = c.String(nullable: false, maxLength: 200),
                        PaswoordHash = c.String(nullable: false, maxLength: 1000),
                        RememberMe = c.Boolean(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Long(nullable: false),
                        Role_RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_RoleId })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Andere Personen",
                c => new
                    {
                        GebruikerId = c.Guid(nullable: false),
                        Hoedanigheid = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GebruikerId)
                .ForeignKey("dbo.Gebruikers", t => t.GebruikerId)
                .Index(t => t.GebruikerId);
            
            CreateTable(
                "dbo.Klant",
                c => new
                    {
                        GebruikerId = c.Guid(nullable: false),
                        KlantDatum = c.DateTime(nullable: false),
                        KlantID = c.Long(nullable: false),
                        KlantNaam = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GebruikerId)
                .ForeignKey("dbo.Gebruikers", t => t.GebruikerId)
                .Index(t => t.GebruikerId);
            
            CreateTable(
                "dbo.Leverancier",
                c => new
                    {
                        GebruikerId = c.Guid(nullable: false),
                        LeverancierDatum = c.DateTime(nullable: false),
                        LeverancierID = c.Long(nullable: false),
                        LeverancierNaam = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GebruikerId)
                .ForeignKey("dbo.Gebruikers", t => t.GebruikerId)
                .Index(t => t.GebruikerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leverancier", "GebruikerId", "dbo.Gebruikers");
            DropForeignKey("dbo.Klant", "GebruikerId", "dbo.Gebruikers");
            DropForeignKey("dbo.Andere Personen", "GebruikerId", "dbo.Gebruikers");
            DropForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Products", "Leverancier_GebruikerId", "dbo.Leverancier");
            DropForeignKey("dbo.FilePaths", "Artikelnummer", "dbo.Products");
            DropForeignKey("dbo.Products", "Categorie_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropIndex("dbo.Leverancier", new[] { "GebruikerId" });
            DropIndex("dbo.Klant", new[] { "GebruikerId" });
            DropIndex("dbo.Andere Personen", new[] { "GebruikerId" });
            DropIndex("dbo.UserRoles", new[] { "Role_RoleId" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.FilePaths", new[] { "Artikelnummer" });
            DropIndex("dbo.Products", new[] { "Leverancier_GebruikerId" });
            DropIndex("dbo.Products", new[] { "Categorie_Id" });
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropTable("dbo.Leverancier");
            DropTable("dbo.Klant");
            DropTable("dbo.Andere Personen");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.FilePaths");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Gebruikers");
        }
    }
}
