using AutoMapper;
using BLL.DTOs.Transactions;
using BLL.DTOs.VehicleTypes;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class TransactionMapper : Profile
    {
        public TransactionMapper()
        {
            CreateMap<Transaction, CreateTransactionRequest>().ReverseMap();
            CreateMap<Transaction, TransactionResponse>().ReverseMap();
        }
    }
}
