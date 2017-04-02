using System;

namespace TransmissionControl
{

    /// <summary>
    /// The Event arguments class when a connection error occurs
    /// </summary>
    public class ConnectionErrorEventArgs: EventArgs
    {
        /// <summary>
        /// The connection error message to pass along
        /// </summary>
        public string Message { get; set; }
    }
}
