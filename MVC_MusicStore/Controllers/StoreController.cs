using MVC_MusicStore.Generic;
using MVC_MusicStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MVC_MusicStore.Controllers
{
    [Authorize]
    [NotifyException]
    public class StoreController : Controller
    {
        MusicStoreContext db = new MusicStoreContext();

        // GET: Store 
        public ActionResult Index()
        {
            var albums = db.AlbumsSet.Include(a => a.Genre).Include(a => a.Artist);
            return View(albums.OrderByDescending(p => p.AlbumId).Take(18));
        } 

        // GET: Browse Album by Genre
        public ActionResult Browse(string Genre)
        { 
            var albums = db.AlbumsSet.Include(a => a.Genre).Include(a => a.Artist);
            var albumslist = albums.Where(a => a.Genre.Name == Genre).Take(14);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_AlbumList", albumslist);
            }
            else
            {
                return View(albumslist);
            }
            
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

        [ChildActionOnly] 
        public ActionResult _GenreMenu()
        {
            var genres = db.GenresSet.ToList();

            return PartialView(genres);
        }
    }
}