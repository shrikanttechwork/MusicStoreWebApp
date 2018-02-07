using MVC_MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_MusicStore.Controllers
{
    public class AlbumController : ApiController
    {
        MusicStoreContext db = new MusicStoreContext();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Album album = db.AlbumsSet.Find(id);
            Genre genre = db.GenresSet.Find(album.GenreId);
            

            return new { AlbumName = album.Title, GenreName = genre.Name };
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}