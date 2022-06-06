using AutoMapper;
using ServerNet.Dtos;
using ServerNet.Instracture;
using ServerNet.Models;

namespace ServerNet.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<ProductParameters, ProductParametersInfo>().ReverseMap();
        }
    }
}