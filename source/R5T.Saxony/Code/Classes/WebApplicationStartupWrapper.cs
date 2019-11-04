using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using IAspNetCoreStartup = Microsoft.AspNetCore.Hosting.IStartup;


namespace R5T.Saxony
{
    /// <summary>
    /// Wraps an <see cref="R5T.Saxony.IWebApplicationStartup"/> instance as an <see cref="Microsoft.AspNetCore.Hosting.IStartup"/> instance.
    /// </summary>
    public class WebApplicationStartupWrapper : IAspNetCoreStartup
    {
        private IWebApplicationStartup WebApplicationStartup { get; }


        public WebApplicationStartupWrapper(IWebApplicationStartup webApplicationStartup)
        {
            this.WebApplicationStartup = webApplicationStartup;
        }

        public void Configure(IApplicationBuilder app)
        {
            this.WebApplicationStartup.Configure(app);
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            this.WebApplicationStartup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
