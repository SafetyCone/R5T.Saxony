using System;

using Microsoft.AspNetCore.Builder;

using R5T.Gaul;


namespace R5T.Saxony
{
    public interface IWebApplicationStartup : IApplicationStartup
    {
        void Configure(IApplicationBuilder applicationBuilder);
    }
}
