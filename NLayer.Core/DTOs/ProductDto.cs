using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        [Range(1,4)]
        public int Stock { get; set; }
        
        public decimal Price { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
