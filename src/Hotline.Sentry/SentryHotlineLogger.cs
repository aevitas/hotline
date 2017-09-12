using System;
using System.Threading.Tasks;
using Hotline.Core;
using Microsoft.Extensions.Options;
using SharpRaven.Core;
using SharpRaven.Core.Data;

namespace Hotline.Sentry
{
    /// <summary>
    ///     Represents an event logger that logs exceptions and various other types of messages to Sentry.io.
    /// </summary>
    /// <seealso cref="IHotline" />
    public class SentryHotlineLogger : IHotline
    {
        private readonly IRavenClient _ravenClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SentryHotlineLogger" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <exception cref="ArgumentNullException">
        ///     options
        ///     or
        ///     Can not instantiate a SentryHotlineLogger without a valid DSN!
        /// </exception>
        public SentryHotlineLogger(IOptions<SentryOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrEmpty(options.Value.Dsn))
                throw new ArgumentNullException("Can not instantiate a SentryHotlineLogger without a valid DSN!");

            var opts = options.Value;

            _ravenClient = new RavenClient(opts.Dsn);
        }

        /// <summary>
        ///     Captures the specified <see cref="T:System.Exception" /> asynchronously.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">exception</exception>
        public async Task CaptureAsync(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            await _ravenClient.CaptureAsync(new SentryEvent(exception));
        }

        /// <summary>
        ///     Captures the specified message asynchronously.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task CaptureAsync(string message)
        {
            var m = new SentryMessage(message);

            await _ravenClient.CaptureAsync(new SentryEvent(m));
        }
    }
}