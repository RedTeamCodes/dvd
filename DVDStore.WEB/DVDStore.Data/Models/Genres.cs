using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVDStore.Data.Models
{
    public class Genres
    {
        public int Id { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
