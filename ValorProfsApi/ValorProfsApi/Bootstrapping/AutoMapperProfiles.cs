using System.Linq;
using ValorProfsApi.Data.Entities;
using ValorProfsApi.Dtos;
using AutoMapper;
using System;

namespace ValorProfsApi.Bootstrapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductToCreateDto, Product>();
            CreateMap<ProductToUpdateDto, Product>();
            CreateMap<Product, ProductToListDto>();
        }
    }
}
