using AutoMapper;
using BLL.DTOs.Employees;
using BLL.DTOs.VehicleTypes;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(
            IMapper mapper,
            IEmployeeRepository employeeRepository
        )
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeResponse> GetAllActive()
        {
            return mapper.Map<IEnumerable<EmployeeResponse>>(employeeRepository.Find(x => x.IsActive));
        }

        public IEnumerable<EmployeeResponse> GetAll()
        {
            return mapper.Map<IEnumerable<EmployeeResponse>>(employeeRepository.GetAll());
        }

        public EmployeeResponse Get(int id)
        {
            return mapper.Map<EmployeeResponse>(employeeRepository.GetById(id));
        }

        public EmployeeResponse Add(CreateEmployeeRequest request)
        {
            return mapper.Map<EmployeeResponse>(employeeRepository.Add(mapper.Map<Employee>(request)));
        }

        public EmployeeResponse Update(int id, CreateEmployeeRequest request)
        {
            var employee = employeeRepository.GetById(id);

            if (employee == null)
            {
                throw new Exception("Pending Implementation...");
            }

            employee.Name = request.Name;
            employee.LastName = request.LastName;
            employee.PersonalNumber = request.PersonalNumber;
            employee.BatchWork = request.BatchWork;
            employee.CommissionPercentage = request.CommissionPercentage;
            employee.StartDate = request.StartDate;
            employee.IsActive = request.IsActive;
            return mapper.Map<EmployeeResponse>(employeeRepository.Update(employee));
        }

        public void Delete(int id)
        {
            var employee = employeeRepository.GetById(id);

            if (employee != null)
            {
                employeeRepository.Remove(employee);
            }
        }
    }
}
