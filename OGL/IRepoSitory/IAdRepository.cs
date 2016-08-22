using System.Linq;
using OGL.Models;

namespace OGL.IRepo
{
    public interface IAdRepository 
    {
        IQueryable<MyAd> PobierzOgloszenia();
        MyAd GetOgloszenieById(int id);
        void UsunOgloszenie(int id);
        void SaveChanges();
        void Dodaj(MyAd myAd);
        void Aktualizuj(MyAd myAd);
        IQueryable<MyAd> PobierzStrone(int? page = 1, int? pageSize=10);
    }
}
