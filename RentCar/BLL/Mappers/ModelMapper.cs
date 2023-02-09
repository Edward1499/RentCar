using AutoMapper;
using BLL.DTOs.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<Model, CreateModelRequest>().ReverseMap();
            CreateMap<Model, ModelResponse>().ReverseMap();
        }
    }
}
