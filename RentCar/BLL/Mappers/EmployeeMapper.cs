using AutoMapper;
using BLL.DTOs.Employees;
using BLL.DTOs.VehicleTypes;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
        }
    }
}
