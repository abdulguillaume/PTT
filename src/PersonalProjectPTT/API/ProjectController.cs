using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalProjectPTT.Interfaces;
using PersonalProjectPTT.Models;
using PersonalProjectPTT.Services;
using Microsoft.AspNetCore.Authorization;

namespace PersonalProjectPTT.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
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
        [HttpGet("{id}")]
        [Authorize]
        public Project Get(int id)
        {
            return _project.GetProject(id);
        }

        // POST: api/Project
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            else if (project.Id == 0)
            {
                project.CreateDate = DateTime.Now;
                project.UpdateDate = project.CreateDate;

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
        [Authorize(Policy = "AdminOnly")]
        public void Delete(int id)
        {
            _project.DeleteProject(id);
        }
    }
}
