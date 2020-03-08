using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class ListViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public CategoryType Category { get; set; }

        public IEnumerable<Article> Articles { get; set; }
    }
}
