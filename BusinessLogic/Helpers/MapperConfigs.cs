using AutoMapper;
using BusinessLogic.ApiModels.Products;
using BusinessLogic.Dtos;
using DataAccess.Entities;

namespace BusinessLogic.Helpers
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap<CreateProductModel, Product>();
            CreateMap<EditProductModel, Product>();

            CreateMap<Product, ProductDto>()/*.ForMember(p => p.CategoryName,
                config => config.MapFrom(p => p.Category.Name))*/.ReverseMap();
        }
    }
}
