using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

using R5T.Gaul;


namespace R5T.Saxony
{
    public class WebApplicationStartupBase : ApplicationStartupBase, IWebApplicationStartup
    {
        public WebApplicationStartupBase(ILogger<WebApplicationStartupBase> logger)
            : base(logger)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            base.Configure(app.ApplicationServices);
        }

        /// <summary>
        /// Base implementation does nothing.
        /// </summary>
        protected virtual void ConfigureBody(IApplicationBuilder app)
        {
            // Do nothing.
        }
    }
}
