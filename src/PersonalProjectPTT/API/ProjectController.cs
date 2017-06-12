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
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        IProjectService _project;

        public ProjectController(IProjectService project)
        {
            _project = project;
        }
        // GET: api/Project
        [HttpGet]
        public List<Project> Get()
        {
            return _project.AllProjects();
        }

        // GET: api/Project/5
        [HttpGet("{id}", Name = "Get")]
        public Project Get(int id)
        {
            return _project.GetProject(id);
        }
        
        // POST: api/Project
        [HttpPost]
        public IActionResult Post([FromBody]Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            else if (project.Id == 0)
            {
                _project.AddProject(project);
                return Ok();
            }
            else
            {
                _project.UpdateProject(project);
                return Ok();
            }
        }

        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _project.DeleteProject(id);
        }
    }
}
