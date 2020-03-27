using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{

    public class SqlArticleData : IArticleData
    {
        const int numberToDisplay = 3;

        private BlogDbContext _context;

        public SqlArticleData(BlogDbContext context)
        {
            _context = context;
        }

        public Article DeleteArticle(int id)
        {
            _context.Remove(_context.Articles.SingleOrDefault(a => a.Id == id));
            _context.SaveChanges();
            return new Article();
        }

        public Article EdditArticle(Article article)
        {
            _context.Attach(article).State = EntityState.Modified;
            _context.SaveChanges();
            return article;
        }

        public Article GetArticle(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Article> GetArticles()
        {            
            return _context.Articles.OrderByDescending(a => a.Date);
        }

        public Article PostArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            return article;
        }
    }
}