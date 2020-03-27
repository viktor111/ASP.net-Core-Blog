using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class AdminViewModel
    {
        public int Id { get; set; }

        public List<ApplicationUser> Users{ get; set; }
    }
}
