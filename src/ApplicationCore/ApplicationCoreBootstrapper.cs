using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Discovery;

namespace Microsoft.eShopWeb.ApplicationCore
{

    public sealed class ApplicationCoreBootstrapper : IServiceDiscoveryBootstrapper
    {
        public ApplicationCoreBootstrapper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private IConfiguration configuration; 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationCoreServices(this.configuration);
        }
    }
}