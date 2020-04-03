using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
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

        public Project DeleteProject(int id)
        {
            _context.Remove(_context.Projects.SingleOrDefault(p => p.Id == id));
            _context.SaveChanges();
            return new Project();
        }

        public Project EdditProject(Project Project)
        {
            _context.Attach(Project).State = EntityState.Modified;
            _context.SaveChanges();
            return Project;
        }

        public Project GetProject(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.OrderByDescending(p => p.Technology);
        }

        public Project PostProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }
    }
}
