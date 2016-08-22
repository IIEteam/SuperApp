using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OGL.Models;

namespace OGL.IRepo
{
    public interface IAdContext
    {
        DbSet<Category> Kategorie { get; set; }
        DbSet<MyAd> Ogloszenia { get; set; }
        DbSet<MyUser> Uzytkownik { get; set; }
        DbSet<AdCategory> Ogloszenie_Kategoria { get; set; }
        DbEntityEntry Entry(object entity);
        int SaveChanges();
        Database Database { get; }
    }
}
