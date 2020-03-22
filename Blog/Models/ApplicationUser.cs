using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Comment> Comments{ get; set; }
    }
}
