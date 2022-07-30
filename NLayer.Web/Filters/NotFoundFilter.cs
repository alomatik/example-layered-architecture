using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;
using NLayer.Web.Models;

namespace NLayer.Web.Filters
{
    public class NotFoundFilter : IAsyncActionFilter
    {

        private readonly IProductService _service;

        public NotFoundFilter(IProductService service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idParameter = context.ActionArguments["id"];
            //var idParameter = context.ActionArguments.Values.FirstOrDefault();
            if (idParameter == null)
            {
                await next.Invoke();
                return;
            }
            int id = (int)idParameter;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);
            if (anyEntity)
            {
                await next.Invoke();
                return;
            }
            ErrorViewModel errorViewModel = new ErrorViewModel()
            {
                Message = "Id bulunamadı.",
            };
            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
        }
    }
}
