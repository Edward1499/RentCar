using AutoMapper;
using BLL.DTOs.Vehicles;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class VehicleMapper : Profile
    {
        public VehicleMapper()
        {
            CreateMap<Vehicle, CreateVehicleRequest>().ReverseMap();
            CreateMap<Vehicle, VehicleResponse>().ReverseMap();
        }
    }
}
