using PersonalProjectPTT.Interfaces;
using PersonalProjectPTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Services
{
    public class EmployeeService: IEmployeeService
    {
        private IGenericRepository _repo;

        public EmployeeService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<Employee> AllEmployees()
        {
            List<Employee> employees = (from e in _repo.Query<ApplicationUser>()
                                   select new Employee {
                                       name= e.UserName
                                   }
                           ).ToList();
            return employees;
        }
    }
}
