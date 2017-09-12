using System;
using System.Threading.Tasks;

namespace Hotline.Core
{
    /// <summary>
    ///     Interface all types representing a Hotline logger should implement.
    /// </summary>
    public interface IHotline
    {
        /// <summary>
        ///     Captures the specified <see cref="Exception" /> asynchronously.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        Task CaptureAsync(Exception exception);

        /// <summary>
        ///     Captures the specified message asynchronously.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task CaptureAsync(string message);
    }
}