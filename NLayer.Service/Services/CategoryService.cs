using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        readonly IMapper _mapper;
        readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> genericRepository, IMapper mapper, ICategoryRepository categoryRepository) : base(unitOfWork, genericRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategorywithProductsDto> GetByCategoryIdwithProductsAsync(int categoryId)
        {
            var categorywithProducts = await _categoryRepository.GetByCategoryIdWithProductsAsync(categoryId);
            var categorywithProductsDto = _mapper.Map<CategorywithProductsDto>(categorywithProducts);
            return categorywithProductsDto;

        }

        public async Task<List<CategorieswithProductsDto>> GetCategorieswithProductsAsync()
        {
            var categorieswProducts = await _categoryRepository.GetCategoriesWithProductsAsync();
            var categorieswProductsDto = _mapper.Map<List<CategorieswithProductsDto>>(categorieswProducts);
            return categorieswProductsDto;
        }
    }
}
