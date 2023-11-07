using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InsuranceCompany.API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = 400;
            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = statusCode,
            };
            context.ExceptionHandled = true;
        }
    }

}

