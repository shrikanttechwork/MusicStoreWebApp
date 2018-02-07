using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_MusicStore.Models
{
    public class MusicStoreContext : DbContext
    {
        public DbSet<Genre> GenresSet { get; set; }
        public DbSet<Artist> ArtistsSet { get; set; }
        public DbSet<Album> AlbumsSet { get; set; }
        public DbSet<User> UsersSet { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}