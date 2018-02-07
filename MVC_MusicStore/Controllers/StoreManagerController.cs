using MVC_MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC_MusicStore.Generic;

namespace MVC_MusicStore.Controllers
{
    //[Authorize(Roles = "admin")]
    //[Authorize]
    [ValidatedUserRoles]
    [NotifyException]
    public class StoreManagerController : Controller
    {
        MusicStoreContext db = new MusicStoreContext();

        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = db.AlbumsSet.Include(a => a.Genre).Include(a => a.Artist);
            return View(albums.OrderByDescending(p => p.AlbumId).Take(10));
        }

        //
        // GET: /StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.GenresSet, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(db.ArtistsSet, "ArtistId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create
        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                db.AlbumsSet.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
             
            ViewBag.GenreId = new SelectList(db.GenresSet, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.ArtistsSet, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // 
        // Get: /StoreManager/Edit/id        
        public ActionResult Edit(int id)
        {
            Album album = db.AlbumsSet.Find(id);
            ViewBag.GenreId = new SelectList(db.GenresSet, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.ArtistsSet, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //Post: /StoreManager/Edit/id
        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.GenresSet, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.ArtistsSet, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // Get: /StoreManager/Details/id        
        public ActionResult Details(int id)
        {
            Album album = db.AlbumsSet.Find(id);
            Genre genre = db.GenresSet.Find(album.GenreId);
            ViewBag.GenereName = genre.Name;
            Artist artist = db.ArtistsSet.Find(album.ArtistId);
            ViewBag.ArtistName = artist.Name;
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    Album album = db.AlbumsSet.Find(id);
        //    return View(album);
        //}

        //
        // POST: /StoreManager/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Album album = db.AlbumsSet.Find(id);
            db.AlbumsSet.Remove(album);
            db.SaveChanges();

            return Json("Success");
        }
    }
}