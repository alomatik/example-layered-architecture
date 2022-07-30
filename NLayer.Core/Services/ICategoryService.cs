﻿using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<List<CategorieswithProductsDto>> GetCategorieswithProductsAsync();
        Task<CategorywithProductsDto> GetByCategoryIdwithProductsAsync(int categoryId);

    }
}
