using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghost.Models
{
    public class Evidence
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Display(Name= "Date and Time Collected")]
        public DateTime Date { get; set; }
        [Required]
        public string Summary { get; set; }

        [Display(Name = "My Audio")]
        public string  MyAudio {get;set;}
        [Display(Name="My Video")]
        public string MyVideo { get; set; }
        public int InvestigationId { get; set; }
        public Investigation Investigation { get; set; }
        public string  UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
