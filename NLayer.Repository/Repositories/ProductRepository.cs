using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        IMapper _mapper;

        public ProductRepository(AppDbContext appDbContext, IMapper mapper) : base(appDbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetProductsWithCategoryAsync()
        {
            //eager..
            return await _context.Set<Product>().Include(p => p.Category).ToListAsync();
        }

        public IList<ProductDto> GetProducts()
        {
            return _context.Products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
