using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;

namespace NLayer.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //var errors = context.ModelState.Values.SelectMany(modelState => modelState.Errors).ToList();/*.Select(x=>x.ErrorMessage).ToList()*/
                var errors2 = context.ModelState.Values.Select(m => m.Errors).ToList();

                List<string> errorList = new List<string>();
                foreach (var item in errors2)
                {
                    foreach (var item2 in item)
                    {
                        errorList.Add(item2.ErrorMessage);
                    }
                }

                context.Result = new BadRequestObjectResult(ResponseDto<NoContentDto>.Fail(400, errorList));

               

            }
        }
    }
}
