using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IProjectData
    {
        IEnumerable<Project> GetProjects();
        Project GetProject(int id);
        Project PostProject(Project article);
        Project EdditProject(Project article);
        Project DeleteProject(int id);
    }
}
