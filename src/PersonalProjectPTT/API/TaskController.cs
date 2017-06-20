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
    [Route("api/[controller]")]
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
        [HttpGet("{id}")]
        public ATask Get(int id)
        {
            return _task.GetTask(id);
        }

        // POST: api/Task
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody]TaskRequest rqst)//[FromBody]ATask task) //changed in order to receive 2 parameters in the post request
        {
            if (rqst == null)
            {
                return BadRequest();
            }
            else if (rqst!=null && rqst.task.Id == 0)
            {
                rqst.task.CreateDate = DateTime.Now;
                rqst.task.UpdateDate = rqst.task.CreateDate;

                _task.AddTask(rqst.projectId, rqst.task);
                return Ok();
            }
            else if(rqst!=null)
            {
                _task.UpdateTask(rqst.task);
                return Ok();
            }

            return BadRequest(); //in case everything has failed
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _task.DeleteTask(id);
        }
    }

    public class TaskRequest
    {
        public int projectId { get; set; }
        public ATask task { get; set; }
    }
}
