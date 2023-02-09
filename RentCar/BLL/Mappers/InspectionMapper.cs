using AutoMapper;
using BLL.DTOs.Inspections;
using BLL.DTOs.VehicleTypes;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class InspectionMapper : Profile
    {
        public InspectionMapper()
        {
            CreateMap<Inspection, CreateInspectionRequest>().ReverseMap();
            CreateMap<Inspection, InspectionResponse>().ReverseMap();
        }
    }
}
