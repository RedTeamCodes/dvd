using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVDStore.Data.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public virtual List<DVD> Movies { get; set; }


    }
}
