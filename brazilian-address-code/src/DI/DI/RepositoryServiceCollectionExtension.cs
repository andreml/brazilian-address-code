using Domain.Interfaces;
using Infraestucture.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DI
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();         

            return services;
        }
    }
}
