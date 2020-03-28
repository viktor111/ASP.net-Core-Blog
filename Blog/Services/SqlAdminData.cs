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

        public ApplicationUser DelteUser(string id)
        {
            _context.Remove(_context.ApplicationUsers.SingleOrDefault(a => a.Id == id));
            _context.SaveChanges();
            return new ApplicationUser();
        }

        public List<ApplicationUser> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Email).ToList();
        }

        public ApplicationUser RestrictUser(string id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser UserDetails(string id)
        {
            return _context.ApplicationUsers.Single(u => u.Id == id);
        }
    }
}
