namespace Microsoft.eShopWeb.Web.Services
{
    using Microsoft.eShopWeb.Web.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebViewModelServices(this IServiceCollection services)
        {
            services.AddScoped<ICatalogViewModelService, CachedCatalogViewModelService>();
            services.AddScoped<IBasketViewModelService, BasketViewModelService>();
            services.AddScoped<CatalogViewModelService>();

            return services;
        }
    }
}
