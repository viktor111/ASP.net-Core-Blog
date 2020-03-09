using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class IndexViewModel
    {
        public List<string> Preview { get; set; }

        public IEnumerable<Article> Articles { get; set; }

        public SortType Sort { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
