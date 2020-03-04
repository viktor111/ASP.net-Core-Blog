using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Test.Models
{
    public class Article
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(60)]
        public string Author { get; set; }

        [Required]
        public CategoryType Category { get; set; }
    }
}
