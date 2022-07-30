using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CategorieswithProductsDto:CategoryDto
    {
        public List<Product> Products { get; set; }
    }
}
