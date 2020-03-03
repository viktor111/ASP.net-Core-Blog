using Blog_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Test.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}
