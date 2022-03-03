using AJSExample.Data.Dtos;
using AJSExample.Models;
using AutoMapper;

namespace AJSExample.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Product MAP
            CreateMap<Product, CreateProductDto>().ReverseMap();
        }
    }
}