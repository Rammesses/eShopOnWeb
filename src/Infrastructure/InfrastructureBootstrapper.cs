namespace Microsoft.eShopWeb.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Discovery;

    public sealed class InfrastructureBootstrapper : IServiceDiscoveryBootstrapper
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructureServices();
        }
    }
}
