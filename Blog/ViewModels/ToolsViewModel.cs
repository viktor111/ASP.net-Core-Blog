using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class ToolsViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Website { get; set; }

    }
}
