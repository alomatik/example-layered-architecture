using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        readonly IProductService _productService;
        readonly IMapper _mapper;
        // readonly IService<Product> _service;

        public ProductsController(IMapper mapper, /*Core.Services.IService<Product> service*/IProductService productService)
        {
            _mapper = mapper;
            //_service = service;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            // return Ok(ResponseDto<List<ProductDto>>.Success(200, productsDto));

            return CreateActionResult<List<ProductDto>>(ResponseDto<List<ProductDto>>.Success(200, productsDto));
            // return StatusCode(200, productsDto);
            //return StatusCode(404, "Hata sizde değil, bizde.");
        }

        //[HttpGet]
        //public async Task<List<ProductDto>> GetAll()
        //{
        //    var products = await _productService.GetAllAsync();
        //    var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
        //    // return Ok(ResponseDto<List<ProductDto>>.Success(200, productsDto));

        //    //return CreateActionResult<List<ProductDto>>(ResponseDto<List<ProductDto>>.Success(200, productsDto));
        //    //return StatusCode(200, productsDto);
        //    //return StatusCode(404, "Hata sizde değil, bizde.");
        //    return productsDto;
        //}
        [TypeFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            //var x = CreateActionResult<ProductDto>(ResponseDto<ProductDto>.Success(200, productDto));
            //return x;
            return StatusCode(200, productDto);
        }

        //[HttpGet("GetProductsWithCategory")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            throw new Exception("asdsadsaAHMET");
            var data = await _productService.GetProductsWithCategoryAsync();
            return StatusCode(200, data);
        }

        //[HttpGet("{id}")]
        //public async Task<ProductDto> GetById(int id)
        //{
        //    var product = await _productService.GetByIdAsync(id);
        //    var productDto = _mapper.Map<ProductDto>(product);
        //    //var x = CreateActionResult<ProductDto>(ResponseDto<ProductDto>.Success(200, productDto));
        //    //return x;
        //    return productDto;
        //}

        [HttpPost]
        [ValidateFilterAttribute]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var newProductDto = _mapper.Map<ProductDto>(product);
            //return CreateActionResult<ProductDto>(ResponseDto<ProductDto>.Success(201, newProductDto));
            return StatusCode(201, newProductDto);

        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
            //return CreateActionResult<ProductDto>(ResponseDto<ProductDto>.Success(201, newProductDto));
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);
            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
            //return CreateActionResult<NoContentDto>(ResponseDto<NoContentDto>.Success(204));
            //return StatusCode(204);
        }


    }
}
