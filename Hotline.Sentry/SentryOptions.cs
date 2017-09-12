namespace Hotline.Sentry
{
    /// <summary>
    ///     Represents a type providing options for logging to Sentry.
    /// </summary>
    public class SentryOptions
    {
        /// <summary>
        ///     Gets or sets the DSN used to establish a connection to Sentry.
        /// </summary>
        public string Dsn { get; set; }
    }
}