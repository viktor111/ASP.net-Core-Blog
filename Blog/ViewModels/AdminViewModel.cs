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

        public string UserEamil { get; set; }

        public string Username { get; set; }

        public List<ApplicationUser> Users{ get; set; }

        public List<Comment> UserComments { get; set; }        
    }
}
