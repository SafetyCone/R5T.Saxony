using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using R5T.Gaul;


namespace R5T.Saxony
{
    public class WebApplicationStartupBase : ApplicationStartupBase, IWebApplicationStartup
    {
        public WebApplicationStartupBase(ILogger<WebApplicationStartupBase> logger)
            : base(logger)
        {
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            base.Configure(applicationBuilder.ApplicationServices);

            var hostingEnvironment = applicationBuilder.ApplicationServices.GetRequiredService<IHostingEnvironment>();

            this.ConfigureBody(applicationBuilder, hostingEnvironment);
        }

        /// <summary>
        /// Base implementation does nothing.
        /// </summary>
        protected virtual void ConfigureBody(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            // Do nothing.
        }
    }
}
