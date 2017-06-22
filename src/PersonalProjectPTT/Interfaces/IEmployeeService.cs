using PersonalProjectPTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> AllEmployees();
    }
}
