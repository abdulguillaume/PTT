using PersonalProjectPTT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProjectPTT.Models;

using Microsoft.EntityFrameworkCore;


namespace PersonalProjectPTT.Services
{
    public class TaskService : ITaskService
    {
        private IGenericRepository _repo;
        private IProjectService _ps;

        public TaskService(IGenericRepository repo, IProjectService ps)
        {
            _repo = repo;
            _ps = ps;
        }

        public void AddTask(ATask task)
        {
            _repo.Add(task);
        }

        public void AddTask(int projectId, ATask task)
        {
            Project project = _ps.GetProject(projectId);

            task.LinkedProject = project;

            _repo.Add(task);
        }

        public List<ATask> AllTasks()
        {
            List<ATask> tasks = (from t in _repo.Query<ATask>()
                          select t
                          ).ToList();
            return tasks;
        }

        public void DeleteTask(int id)
        {
            ATask toDelete = GetTask(id);

            foreach (Comment c in toDelete.Comments.ToList())
            {
                _repo.Delete<Comment>(c);
            }
            
            _repo.Delete(toDelete);
        }

        public ATask GetTask(int id)
        {
            ATask task = (from t in _repo.Query<ATask>()
                          .Include(c=>c.Comments)
                               where t.Id == id
                               select t
                          ).FirstOrDefault();
            return task;
        }

        public void UpdateTask(ATask task)
        {
            _repo.Update(task);
        }
    }
}
