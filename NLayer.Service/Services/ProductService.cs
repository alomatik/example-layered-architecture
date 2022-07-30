using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        readonly IProductRepository _productRepository;
        readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> genericRepository, IProductRepository productRepository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<ProductsWithCategoryDto>> IProductService.GetProductsWithCategoryAsync()
        {
            var products = await _productRepository.GetProductsWithCategoryAsync();

            IEnumerable<string> strings = new List<string>();
            ICollection<string> strings1 = new List<string>();
            strings.Count();

            var productsWCategoryDto= _mapper.Map<List<ProductsWithCategoryDto>>(products);
            return productsWCategoryDto;
        }
    }
}
