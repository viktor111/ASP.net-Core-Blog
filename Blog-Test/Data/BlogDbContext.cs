using Blog_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Test.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
    }
}
