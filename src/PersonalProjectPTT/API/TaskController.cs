using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalProjectPTT.Interfaces;
using PersonalProjectPTT.Models;

namespace PersonalProjectPTT.API
{
    [Produces("application/json")]
    [Route("api/Task")]
    public class TaskController : Controller
    {
        private ITaskService _task;

        public TaskController(ITaskService task)
        {
            _task = task;
        }


        // GET: api/Task
        [HttpGet]
        public List<ATask> Get()
        {
            return _task.AllTasks();
        }

        // GET: api/Task/5
        [HttpGet("{id}", Name = "Get")]
        public ATask Get(int id)
        {
            return _task.GetTask(id);
        }
        
        // POST: api/Task
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody]ATask task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            else if (task.Id == 0)
            {
                _task.AddTask(task);
                return Ok();
            }
            else
            {
                _task.UpdateTask(task);
                return Ok();
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _task.DeleteTask(id);
        }
    }
}
