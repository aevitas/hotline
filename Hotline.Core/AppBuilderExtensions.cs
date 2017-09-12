using System;
using Microsoft.AspNetCore.Builder;

namespace Hotline.Core
{
    public static class AppBuilderExtensions
    {
        /// <summary>
        ///     Uses the Hotline middleware to catch and report exceptions that occur during requests.
        /// </summary>
        /// <param name="applicationBuilder">The application builder.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">applicationBuilder</exception>
        public static IApplicationBuilder UseHotline(this IApplicationBuilder applicationBuilder)
        {
            if (applicationBuilder == null)
                throw new ArgumentNullException(nameof(applicationBuilder));

            return applicationBuilder.UseMiddleware<HotlineMiddleware>();
        }
    }
}