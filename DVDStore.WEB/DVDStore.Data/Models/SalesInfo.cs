using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVDStore.Data.Models
{
    public class SalesInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual DVD DVDId { get; set; }
        public decimal Sold
        {
            get; set;
        }
    }
}
