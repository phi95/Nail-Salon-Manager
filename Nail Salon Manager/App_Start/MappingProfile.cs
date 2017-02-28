using AutoMapper;
using Nail_Salon_Manager.Dtos;
using Nail_Salon_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nail_Salon_Manager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.CreateMap<EmployeeDto, Employee>();

            Mapper.CreateMap<Transaction, TransactionDto>();
            Mapper.CreateMap<TransactionDto, Transaction>();

            Mapper.CreateMap<InventoryItem, InventoryItemDto>();
            Mapper.CreateMap<InventoryItemDto, InventoryItem>();
        }
    }
}