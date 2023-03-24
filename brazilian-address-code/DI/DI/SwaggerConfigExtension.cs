using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace CrossCutting.DI
{
    public static class SwaggerConfigExtension
    {
        public static IServiceCollection AddSwaggerConfigExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Search address by zipCode", Version = "v1" });
                c.ResolveConflictingActions(a => a.FirstOrDefault());
            });

            return services;
        }
    }
}
