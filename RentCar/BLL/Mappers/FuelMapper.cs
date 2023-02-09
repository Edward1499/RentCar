using AutoMapper;
using BLL.DTOs.Fuels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class FuelMapper : Profile
    {
        public FuelMapper()
        {
            CreateMap<Fuel, CreateFuelRequest>().ReverseMap();
            CreateMap<Fuel, FuelResponse>().ReverseMap();
        }
    }
}
