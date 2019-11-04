using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Gaul;
using R5T.Herulia.Extensions;
using R5T.Sardinia;

using AspNetCoreStartup = Microsoft.AspNetCore.Hosting.IStartup;


namespace R5T.Saxony
{
    public static class WebApplicationBuilder
    {
        public static IWebHost UseStartup<TStartup>()
            where TStartup : class, IWebApplicationStartup
        {
            // Build the standard startup.
            var webApplicationStartup = ApplicationBuilder.GetApplicationStartup<TStartup>();

            // Configuration.
            var webApplicationConfigurationBuilder = new ConfigurationBuilder();

            webApplicationStartup.ConfigureConfiguration(webApplicationConfigurationBuilder);

            var webApplicationConfiguration = webApplicationConfigurationBuilder.Build();

            // Configure services, Configure service instances, and Configure(IApplicationBuilder).
            var webHostBuilder = WebApplicationBuilder.GetDefaultWebHostBuilder(webApplicationConfiguration, webApplicationStartup);

            var webHost = webHostBuilder.Build();
            return webHost;
        }

        /// <summary>
        /// Add the web application startup instance as the service instance for <see cref="Microsoft.AspNetCore.Hosting.IStartup"/>.
        /// </summary>
        private static IWebHostBuilder GetDefaultWebHostBuilder(IConfiguration configuration, IWebApplicationStartup webApplicationStartup)
        {
            var webApplicationStartupWrapper = new WebApplicationStartupWrapper(webApplicationStartup);

            var webHostBuilder = new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseKestrel()
                .UseDefaultContentRoot()
                .UseIISIntegration()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<AspNetCoreStartup>(webApplicationStartupWrapper);
                })
                ;

            return webHostBuilder;
        }
    }
}
