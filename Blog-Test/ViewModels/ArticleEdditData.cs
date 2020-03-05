using Blog_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blog_Test.ViewModels
{
    public class ArticleEdditData
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public CategoryType Category { get; set; }
    }
}
