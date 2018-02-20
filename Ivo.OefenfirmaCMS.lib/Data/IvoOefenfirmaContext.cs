using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivo.OefenfirmaCMS.lib.Entities;

namespace Ivo.OefenfirmaCMS.lib.Data
{
    public class IvoOefenfirmaContext : DbContext
    {
        public DbSet<Categorie> Categorieen { get; set; }
        public DbSet<Product> Producten { get; set; }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Leverancier> Leveranciers { get; set; }
        public DbSet<AnderePersonen> AnderePersonen { get; set; }

        public DbSet<User>User { get; set; }
        public DbSet<Role>Roles { get; set; }


        //Bedoeld om files in te lezen = to do
        public DbSet<FilePaths> Files { get; set; }


        public class CommodityCategoryMap : EntityTypeConfiguration<Categorie>
        {
            public CommodityCategoryMap()
            {
                HasKey(x => x.Id);

                Property(x => x.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

                Property(x => x.Categorienaam)
                    .IsRequired()
                    .HasMaxLength(255);

                HasOptional(x => x.Parent)
                    .WithMany(x => x.Children)
                    .HasForeignKey(x => x.ParentId)
                    .WillCascadeOnDelete(false);
            }
        }
    }
}
