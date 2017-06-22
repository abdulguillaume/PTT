using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalProjectPTT.Services;
using PersonalProjectPTT.Models;
using PersonalProjectPTT.Interfaces;

namespace PersonalProjectPTT.API
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        IEmployeeService _emps;

        public EmployeeController(IEmployeeService emps)
        {
            _emps = emps;
        }

        // GET: api/Employee
        [HttpGet]
        public List<Employee> Get()
        {
            return _emps.AllEmployees();
        }

     
    }
}
