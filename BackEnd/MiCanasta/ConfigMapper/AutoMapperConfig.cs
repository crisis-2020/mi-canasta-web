using AutoMapper;
using MiCanastaBE.Dto;
using MiCanastaBE.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.BackEnd.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Product, ProductDto>();

        }
    }
}
