using Blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class ProjectsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Ttitle { get; set; }

        [Required]
        public string GitHubLink { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TechnologyType Technology { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}
