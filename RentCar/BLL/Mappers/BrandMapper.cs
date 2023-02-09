using AutoMapper;
using BLL.DTOs.Brands;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class BrandMapper : Profile
    {
        public BrandMapper()
        {
            CreateMap<Brand, CreateBrandRequest>().ReverseMap();
            CreateMap<Brand, BrandResponse>().ReverseMap();
        }
    }
}
