using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idParameter= context.ActionArguments["id"];
            var idParameter2 = context.ActionArguments.Values.FirstOrDefault();
            if (idParameter==null)
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

            context.Result = new NotFoundObjectResult(ResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name} not foundd."));
        }
    }
}
