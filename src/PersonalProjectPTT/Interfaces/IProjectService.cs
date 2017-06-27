using PersonalProjectPTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Interfaces
{
    public interface IProjectService
    {
        List<Project> AllProjects();
        void AddProject(Project project);
        void DeleteProject(int id);
        Project GetProject(int id);
        void UpdateProject(Project project);
        List<Project> GetProjectsByClientName(string client);
    }
}
