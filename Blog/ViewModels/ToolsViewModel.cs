using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class ToolsViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Website { get; set; }

        public string[] OpenPorts { get; set; }

        public string Target { get; set; }
    }
}
