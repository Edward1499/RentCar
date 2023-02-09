using BLL.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeResponse> GetAllActive();
        IEnumerable<EmployeeResponse> GetAll();
        EmployeeResponse Get(int id);
        EmployeeResponse Add(CreateEmployeeRequest request);
        EmployeeResponse Update(int id, CreateEmployeeRequest request);
        void Delete(int id);
    }
}
