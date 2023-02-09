using AutoMapper;
using BLL.DTOs.VehicleTypes;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class VehicleTypeMapper : Profile
    {
        public VehicleTypeMapper()
        {
            CreateMap<VehicleType, CreateVehicleTypeRequest>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeResponse>().ReverseMap();
        }
    }
}
