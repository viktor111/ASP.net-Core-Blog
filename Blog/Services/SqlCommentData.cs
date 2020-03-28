using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class SqlCommentData : ICommentData
    {
        private BlogDbContext _context;

        public SqlCommentData(BlogDbContext context)
        {
            _context = context;
        }

        public Comment DeleteComment(int id)
        {
            _context.Remove(_context.Comments.SingleOrDefault(a => a.Id == id));
            _context.SaveChanges();
            return new Comment();
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            return _context.Comments.Where(c => c.ArticleId == id);
        }

        public IEnumerable<Comment> GetCommentsForUser(string id)
        {
            return _context.Comments.Where(c => c.ApplicationUser.Id == id);
        }

        public Comment PostComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }
    }
}
