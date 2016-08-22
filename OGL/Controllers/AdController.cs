using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OGL.IRepo;
using OGL.Models;
using PagedList;
namespace OGL.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdRepository _repo;
        public AdController(IAdRepository repo)
        {
            _repo = repo;
        }
       

        // GET: MyAd
       
        public ActionResult Index(int? page)
        {
            int currentPage = page ?? 1;
            int naStronie = 5;
            var ogloszenia = _repo.PobierzOgloszenia();
            ogloszenia = ogloszenia.OrderByDescending(d => d.DataDodania);
            
            return View(ogloszenia.ToPagedList<MyAd>(currentPage,naStronie));

        }

        // GET: MyAd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyAd myAd = _repo.GetOgloszenieById((int)id);
            if (myAd == null)
            {
                return HttpNotFound();
            }
            return View(myAd);
        }

        // GET: MyAd/Create
        [Authorize]
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: MyAd/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tresc,Tytul")] MyAd myAd)
        {
            if (ModelState.IsValid)
            {
                myAd.UzytkownikId = User.Identity.GetUserId();
                myAd.DataDodania = DateTime.Now;  
                try
                {
                    _repo.Dodaj(myAd);
                    _repo.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View(myAd);
                }
              
            }

           
            return View(myAd);
        }

        // GET: MyAd/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyAd myAd =_repo.GetOgloszenieById((int)id);
            if (myAd == null)
            {
                return HttpNotFound();
            }
          else if (myAd.UzytkownikId != User.Identity.GetUserId() && !(User.IsInRole("Admin") || User.IsInRole("Pracownik")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(myAd);
        }

        // POST: MyAd/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tresc,Tytul,DataDodania, UzytkownikId")] MyAd myAd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Aktualizuj(myAd);
                    _repo.SaveChanges();
                }
                catch(Exception ex)
                {
                    ViewBag.Blad =true;
                    return View(myAd);
                }
             
            }
            ViewBag.Blad = false;
            return View(myAd);
        }

        // GET: MyAd/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, bool? blad)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyAd myAd = _repo.GetOgloszenieById((int)id);
            if (myAd == null)
            {
                return HttpNotFound();
            }
           
            else if (myAd.UzytkownikId != User.Identity.GetUserId() && !(User.IsInRole("Admin") || User.IsInRole("Pracownik")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (blad != null)
            {
                ViewBag.Blad = true;
            }
            return View(myAd);
        }

        // POST: MyAd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.UsunOgloszenie(id);
            try
            {
                _repo.SaveChanges();
         
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, blad = true });
            }
            return RedirectToAction("Index");
        }
    }
}
