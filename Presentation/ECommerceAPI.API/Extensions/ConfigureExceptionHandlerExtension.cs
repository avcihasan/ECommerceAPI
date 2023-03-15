using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace ECommerceAPI.API.Extensions
{
    static public class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication webApplication)
        {
            webApplication.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "text/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    
                    if(contextFeature != null)
                    {
                        //loglama

                       await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCodeContext=context.Response.StatusCode,
                            Meesage=contextFeature.Error.Message,
                            Title="Hata ALındı !"
                        }));
                    }
                });
            });
        }
    }
}
