using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghost.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Summary { get; set; }
        public string PhNumber { get; set; }
        public string Hours { get; set; }
        public List<Investigation> Investigations { get; set; } = new List<Investigation>();
        


    }
}
