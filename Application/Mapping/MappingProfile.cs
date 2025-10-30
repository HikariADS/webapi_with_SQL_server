using AutoMapper;
using WebApi_With_SQL_Server.Application.DTOs;
using WebApi_With_SQL_Server.Domain.Entities;

namespace WebApi_With_SQL_Server.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
