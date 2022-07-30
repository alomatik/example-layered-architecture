using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayer.Web.Models;

namespace NLayer.Web.Filters
{
    public class MvcExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel()
            {
                Message = context.Exception.Message,
            };

            ViewResult viewResult = new ViewResult()
            {
                ViewName = "Error",
            };
            viewResult.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);
            viewResult.ViewData.Add("MvcErrorModel", errorViewModel);
            context.Result = viewResult;
        }

    }
}
