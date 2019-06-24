namespace Microsoft.eShopWeb.Infrastructure
{
    using Microsoft.eShopWeb.ApplicationCore.Interfaces;
    using Microsoft.eShopWeb.Infrastructure.Data;
    using Microsoft.eShopWeb.Infrastructure.Logging;
    using Microsoft.eShopWeb.Infrastructure.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
