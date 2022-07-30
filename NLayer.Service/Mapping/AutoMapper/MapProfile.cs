using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<ProductFeature, ProductFeature>().ReverseMap();

            CreateMap<ProductUpdateDto, Product>();

            CreateMap<Product, ProductsWithCategoryDto>();

            CreateMap<Category, CategorieswithProductsDto>();

            CreateMap<Category, CategorywithProductsDto>();     


        }
    }
}
