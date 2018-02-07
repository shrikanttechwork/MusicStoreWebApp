using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_MusicStore.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "An Album Artist is required")]
        [DisplayName("Artist")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "An Album Genre is required")]
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        public string Title { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "An Album Url is required")]
        [DisplayName("Album Art URL")]
        public string AlbumArtUrl { get; set; }

        [Required(ErrorMessage = "Album Active Mode is required")]
        public byte Is_active { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}