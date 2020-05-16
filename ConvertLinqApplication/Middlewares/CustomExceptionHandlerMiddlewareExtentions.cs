using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ConvertLinqApplication.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;

namespace ConvertLinqApplication.Middlewares
{
    public static class CustomExceptionHandlerMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler( this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        public CustomExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke (HttpContext context)
        {
            List<string> Message = new List<string>();
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            ApiResultStatusCode apiResultStatusCode = ApiResultStatusCode.ServerError;
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if(_env.IsDevelopment())
                {
                    var error = new Dictionary<string, string>
                    {
                        ["Exception"] = ex.Message,
                        ["StackTrace"] = ex.StackTrace
                    };
                    Message.Add(JsonConvert.SerializeObject(error));
                  
                }
                else
                {
                    Message.Add("خطایی رخ داده است");
                }
                await WriteToResponseAsync();

            }
            async Task WriteToResponseAsync()
            {
                var result = new ApiResult(false, apiResultStatusCode, Message);
                var jsonResult = JsonConvert.SerializeObject(result);

                context.Response.StatusCode = (int)httpStatusCode;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(jsonResult);

            }
        }
    }
}
