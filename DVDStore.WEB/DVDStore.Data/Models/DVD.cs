using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
using System.Data.Entity;



namespace DVDStore.Data.Models
{
    
    public class DVD
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        //public byte[] Picture { get; set; }
        // Foreign Key
        public virtual Ratings RatingsID { get; set; }
        // Foreign Key
        public virtual Genres GenresID { get; set; }
        // Foreign Key
        public virtual SalesInfo SalesInfoID { get; set; }
        //Foreign Key
        public virtual ICollection<Actor> Actors { get; set; }
    }

    
    public class MovieDBContext : DbContext
    {
        public DbSet<DVD> DVDs { get; set; }
    }
}
