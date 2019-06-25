using System.Collections.Generic;
using Ardalis.ListStartupServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.eShopWeb.Web.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Discovery;
using Swashbuckle.AspNetCore.Swagger;

namespace Microsoft.eShopWeb.Web
{
    public sealed class WebBootstrapper : IServiceDiscoveryBootstrapper
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add memory cache services
            services.AddMemoryCache();

            services.AddRouting(options =>
            {
                // Replace the type and the name used to refer to it with your own
                // IOutboundParameterTransformer implementation
                options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
            });

            services.AddMvc(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(
                         new SlugifyParameterTransformer()));

            })
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/Basket/Checkout");
                    options.AllowAreas = true;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddHealthChecks()
                .AddCheck<HomePageHealthCheck>("home_page_health_check")
                .AddCheck<ApiHealthCheck>("api_health_check");

            services.Configure<ServiceConfig>(config =>
            {
                config.Services = new List<ServiceDescriptor>(services);

                config.Path = "/allservices";
            });
        }
    }
}
