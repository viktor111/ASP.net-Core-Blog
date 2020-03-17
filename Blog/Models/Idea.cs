using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Idea
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Ttitle { get; set; }

        [Required]
        [MaxLength(245)]
        public string  Description { get; set; }

        [Required]
        public TechnologyType Technology { get; set; }

        public string Email { get; set; }

        [Required]
        [MaxLength(150)]
        public string GitHub { get; set; }

        [Required]
        [MaxLength(155)]
        public string Discord { get; set; }

    }
}
