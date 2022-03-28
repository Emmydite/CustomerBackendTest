using AutoMapper;
using Customer.BLL.Models;
using Customer.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.BLL.Mapper
{
   public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerModel, DAL.Entities.Customer>();
        }
    }
}
