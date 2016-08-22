using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using OGL.IRepo;

namespace OGL.Models
{
    // You can add profile data for the user by adding more properties to your Uzytkownikr class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    public class AdContext : IdentityDbContext, IAdContext
    {
        public AdContext()
            : base("MyConnections")
        {
        }

        public static AdContext Create()
        {
            return new AdContext();
        }
        public DbSet<Category> Kategorie { get; set; }
        public DbSet<MyAd> Ogloszenia { get; set; }
        public DbSet<MyUser> Uzytkownik { get; set; }
        public DbSet<AdCategory> Ogloszenie_Kategoria { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<MyAd>().HasRequired(
                x => x.MyUser).WithMany(x => x.Ogloszenia).HasForeignKey(x=>x.UzytkownikId).WillCascadeOnDelete(true);

        }

    }
}