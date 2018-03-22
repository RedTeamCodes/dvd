using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVDStore.Data.Models
{
    public class ActorsinMovies
    {
        public int Id { get; set; }
        [Required]
        // Foreign Key
        public int ActorID { get; set; }
        public int DVDID { get; set; }
  
    }
}
