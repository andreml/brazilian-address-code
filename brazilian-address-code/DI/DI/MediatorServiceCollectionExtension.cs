using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;

namespace CrossCutting.DI
{
    public static class MediatorServiceCollectionExtension
    {
        public static IServiceCollection AddMediatorExtension(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("App");
            services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
