using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;
using NLayer.Web.Filters;
using NLayer.Web.Models;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        //readonly IMapper _mapper;
        //readonly IProductService _productService;
        //readonly ICategoryService _categoryService;
        readonly ProductApiService _productApiService;
        readonly CategoryApiService _categoryApiService;

        public ProductsController(/*IProductService productService, IMapper mapper, ICategoryService categoryService, */ProductApiService productApiService, CategoryApiService categoryApiService)
        {
            //_productService = productService;
            //_mapper = mapper;
            //_categoryService = categoryService;
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            //var products = await _productService.GetAllAsync();

            //var productsDto = _mapper.Map<List<ProductDto>>(products);

            //return View(productsDto);
            var products = await _productApiService.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> Save()
        {
            var categories = await _categoryApiService.GetAllCategory();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
               var x= await _productApiService.Save(productDto);
                return RedirectToAction("Index");

            }
            var categories = await _categoryApiService.GetAllCategory();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View(productDto);
        }

       // [TypeFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Update(int id)
        {

            var product = await _productApiService.GetByIdAsync(id);
            var categories = await _categoryApiService.GetAllCategory();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.Update(productDto);
                return RedirectToAction("Index");

            }

            var categories = await _categoryApiService.GetAllCategory();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View(productDto);

        }



        //    public async Task<IActionResult> Delete(int id)
        //    {
        //        var product = await _productService.GetByIdAsync(id);

        //        await _productService.RemoveAsync(product);

        //        return RedirectToAction("Index");


        //    }
    }
}
