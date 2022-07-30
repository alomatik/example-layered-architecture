using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetByCategoryIdWithProductsAsync(int categoryId)
        {
            return await _context.Categories.Include(c => c.Products).Where(c => c.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<IList<Category>> GetCategoriesWithProductsAsync()
        {
            return await  _context.Set<Category>().Include(c => c.Products).ToListAsync();
        }
    }
}
