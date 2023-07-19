using EmployeePortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Data
{
    public class InMemoryEmployeeData : IEmployeeData
    {
        List<Employee> employees;

        public InMemoryEmployeeData()
        {
            employees = new List<Employee>()
            {
                new Employee{ Id = 1, Name = "Tladi", Surname = "Kekana" },
                new Employee{ Id = 2, Name = "Adrian", Surname = "Reddy" },
                new Employee{ Id = 3, Name = "Don", Surname = "Mkasi" },
                new Employee{ Id = 4, Name = "Celma", Surname = "Van Zyl" }
            };
        }

        public IEnumerable<Employee> GetAll()
        {
            //Arrange employee list by name in assending order
            return from e in employees
                   orderby e.Name
                   select e;
        }
    }
}
