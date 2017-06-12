using PersonalProjectPTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Interfaces
{
    public interface ITaskService
    {
        List<ATask> AllTasks();
        void AddTask(ATask task);
        void DeleteTask(int id);
        ATask GetTask(int id);
        void UpdateTask(ATask task);
    }
}
