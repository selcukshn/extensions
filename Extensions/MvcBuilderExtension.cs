using Extensions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Extensions
{
    public static class MvcBuilderExtension
    {
        public static IMvcBuilder SuppressFluentValidationExceptionModel<T>(this IMvcBuilder builder)
        where T : Response, new()
        {
            builder.ConfigureApiBehaviorOptions(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    var errors = new List<string>();
                    foreach (var value in context.ModelState.Values)
                    {
                        foreach (var error in value.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }
                    return new BadRequestObjectResult(new T() { Message = "...", Errors = errors });
                };
            });
            return builder;
        }
        public static IMvcBuilder DisableJsonResultParametersNamingPolicy(this IMvcBuilder builder)
        {
            builder.AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            return builder;
        }
    }
}