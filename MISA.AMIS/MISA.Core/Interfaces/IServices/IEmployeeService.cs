using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.IServices
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        bool CheckEmployeeCodeExist(Employee employee);

        bool ValidateObject(Employee employee);
    }
}
