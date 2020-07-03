using Microsoft.AspNetCore.Hosting;
using System;

namespace API
{
    public static class WebHostBuilder
    {
        public static IWebHostBuilder UsePort(this IWebHostBuilder builder)
        {
            var port = Environment.GetEnvironmentVariable("PORT");
            if (string.IsNullOrEmpty(port))
            {
                return builder;
            }

            return builder.UseUrls($"http://+:{port}");
        }
    }
}
