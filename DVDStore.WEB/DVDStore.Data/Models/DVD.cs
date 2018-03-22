using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVDStore.Data.Models
{
    public class DVD
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        //public byte[] Picture { get; set; }


        // Foreign Key
        public int ActorID { get; set; }
        // Foreign Key
        public int RatingsID { get; set; }
        // Foreign Key
        public int GenresID { get; set; }
        // Foreign Key
        public int SalesInfoID { get; set; }
        // Navigation property
        // Navigation property
        public Actor Actor { get; set; }
    }
}
