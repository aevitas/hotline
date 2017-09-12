using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hotline.Core
{
    /// <summary>
    ///     Represents middleware that catches and logs exceptions that occur during execution of the request pipeline.
    /// </summary>
    public class HotlineMiddleware
    {
        private readonly IHotline _hotline;
        private readonly RequestDelegate _request;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HotlineMiddleware" /> class.
        /// </summary>
        /// <param name="hotline">The hotline we'll be calling to capture exceptions.</param>
        /// <param name="request">The request.</param>
        /// <exception cref="ArgumentNullException">hotline</exception>
        public HotlineMiddleware(IHotline hotline, RequestDelegate request)
        {
            _hotline = hotline ?? throw new ArgumentNullException(nameof(hotline));
            _request = request ?? throw new ArgumentNullException(nameof(request));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                await _hotline.CaptureAsync(ex);

                // We're not handling - just logging. Just pass the exception along in case someone's interested in handling it.
                throw;
            }
        }
    }
}