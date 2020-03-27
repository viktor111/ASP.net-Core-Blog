using Blog.Data;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class SqlAdminData : IAdmin
    {

        private BlogDbContext _context;

        public SqlAdminData(BlogDbContext context)
        {
            _context = context;
        }

        public ApplicationUser DelteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Email).ToList();
        }

        public ApplicationUser RestrictUser(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser UserDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
