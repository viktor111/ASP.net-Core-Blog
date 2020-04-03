using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IProjectData
    {
        IEnumerable<Project> GetArticles();
        Project GetArticle(int id);
        Project PostArticle(Project article);
        Project EdditArticle(Project article);
        Project DeleteArticle(int id);
    }
}
