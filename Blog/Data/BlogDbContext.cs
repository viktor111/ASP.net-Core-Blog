using System;
using System.Collections.Generic;
using System.Text;
using Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>().
                HasOne(c => c.ApplicationUser).
                WithMany(u => u.Comments).
                HasForeignKey(c => c.ApplicationUserId);

            modelBuilder.Entity<Comment>().
                HasOne(c => c.Article).
                WithMany(a => a.Comments).
                HasForeignKey(c => c.ArticleId);

            
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
