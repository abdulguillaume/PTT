using PersonalProjectPTT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProjectPTT.Models;

namespace PersonalProjectPTT.Services
{
    public class TaskService : ITaskService
    {
        private IGenericRepository _repo;

        public TaskService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public void AddTask(ATask task)
        {
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
            _repo.Delete(toDelete);
        }

        public ATask GetTask(int id)
        {
            ATask task = (from t in _repo.Query<ATask>()
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
