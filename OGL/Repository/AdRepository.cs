using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using OGL.IRepo;
using OGL.Models;

namespace OGL.Repo
{
    public class AdRepository: IAdRepository

    {
        private readonly IAdContext _db;
        public AdRepository(IAdContext db)
        {
            _db = db;
        }
        //private AdContext db = new AdContext();
        public IQueryable<MyAd> PobierzOgloszenia()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            var ogloszenia = _db.Ogloszenia.AsNoTracking();
            return ogloszenia;
        }
        public MyAd GetOgloszenieById(int id)
        {
            MyAd myAd = _db.Ogloszenia.Find(id);
            return myAd;
        }
        private void UsunPowiazanieOgloszenieKategori(int idOgloszenia)
        {
            var list = _db.Ogloszenie_Kategoria.Where(o => o.OgloszenieId == idOgloszenia);
            foreach (var el in list)
            {
                _db.Ogloszenie_Kategoria.Remove(el);
            }
        }

        public void UsunOgloszenie(int id)
        {
            UsunPowiazanieOgloszenieKategori(id);
            MyAd myAd = _db.Ogloszenia.Find(id);
            _db.Ogloszenia.Remove(myAd);
           

          
        }
        public void Dodaj(MyAd myAd)
        {
            _db.Ogloszenia.Add(myAd);
        }      
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
        public void Aktualizuj(MyAd myAd)
        {
            _db.Entry(myAd).State = EntityState.Modified;
        }
        public IQueryable<MyAd> PobierzStrone(int? page=1,int? pageSize = 10)
        {
            var ogloszenia=_db.Ogloszenia.OrderByDescending(o=>o.DataDodania).Skip((page.Value-1)*pageSize.Value).Take(pageSize.Value);
            return ogloszenia;

        }
    }
}