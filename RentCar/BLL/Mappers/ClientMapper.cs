using AutoMapper;
using BLL.DTOs.Clients;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            CreateMap<Client, CreateClientRequest>().ReverseMap();
            CreateMap<Client, ClientResponse>().ReverseMap();
        }
    }
}
