using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IAdmin
    {
        List<ApplicationUser> GetUsers();
        ApplicationUser DelteUser(int id);
        ApplicationUser RestrictUser(int id);
        ApplicationUser UserDetails(int id);
    }
}
