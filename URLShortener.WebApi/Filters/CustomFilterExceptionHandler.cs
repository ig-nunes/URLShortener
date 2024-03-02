using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using URLShortener.Dados.CustomExceptions;
using URLShortener.WebApi.ResponseModels;

namespace URLShortener.WebApi.Filters
{
    public class CustomFilterExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidUrlException invalidUrlException)
            {
                var result = new ErrorResponse 
                {
                    Title = "Error Api",
                    ErrorMessage = invalidUrlException.Message,
                    StatusCode = invalidUrlException.StatusCode
                };
                context.Result = new JsonResult(result);
                context.ExceptionHandled = true;
            } 
            else
            {
                var result = new ErrorResponse
                {
                    Title = "Error Api",
                    ErrorMessage = "Erro interno dp servidor",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                context.Result = new JsonResult(result) 
                {
                    StatusCode = result.StatusCode,
                };
                context.ExceptionHandled = true;
            }

        }
    }
}
