using AutoMapper;
using BLL.DTOs.Brands;
using BLL.DTOs.VehicleImages;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class VehicleImageMapper : Profile
    {
        public VehicleImageMapper()
        {
            CreateMap<VehicleImage, VehicleImageDTO>().ReverseMap();
        }
    }
}
