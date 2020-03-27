using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Ttitle { get; set; }

        public string GitHubLink { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

    }
}
