using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.eShopWeb.ApplicationCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CatalogSettings>(configuration);

            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
services.AddSingleton<IUriComposer>(provider => new UriComposer(provider.GetRequiredService<IConfiguration>().Get<CatalogSettings>()));
            return services;
        }
    }
}
