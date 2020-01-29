using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghost.Models
{
    public class Investigation
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
        public string Name { get; set; }
        public string Summary { get; set; }
        public bool isPrivate { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Evidence> Evidence { get; set; } = new List<Evidence>();

    }
}
