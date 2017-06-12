using PersonalProjectPTT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProjectPTT.Models;

namespace PersonalProjectPTT.Services
{
    public class ProjectService : IProjectService
    {
        private IGenericRepository _repo;

        public ProjectService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public void AddProject(Project project)
        {
            _repo.Add(project);
        }

        public List<Project> AllProjects()
        {
            List<Project> projects = (from p in _repo.Query<Project>()
                               select p
                          ).ToList();
            return projects;
        }

        public void DeleteProject(int id)
        {
            Project toDelete = GetProject(id);
            _repo.Delete(toDelete);
        }

        public Project GetProject(int id)
        {
            Project project = (from p in _repo.Query<Project>()
                          where p.Id == id
                          select p
                          ).FirstOrDefault();
            return project;
        }

        public void UpdateProject(Project project)
        {
            _repo.Update(project);
        }
    }
}
