using EmployeePortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Data
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
    }
}
