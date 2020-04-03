using Blog.Data;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class SqlProjectData : IProjectData
    {
        private BlogDbContext _context;

        public SqlProjectData(BlogDbContext context)
        {
            _context = context;
        }

        public Project DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }

        public Project EdditArticle(Project article)
        {
            throw new NotImplementedException();
        }

        public Project GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetArticles()
        {
            throw new NotImplementedException();
        }

        public Project PostArticle(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }
    }
}
