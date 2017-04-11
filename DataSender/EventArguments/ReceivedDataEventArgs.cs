using System;

namespace TransmissionControl
{
    /// <summary>
    /// The receive data event arguments class to pass along received data from a server
    /// </summary>
    public class ReceivedDataEventArgs : EventArgs
    {
        /// <summary>
        /// An array of doubles of data from a server. 
        /// Used for server statistics.
        /// </summary>
        public double[] Data { get; set; }
        /// <summary>
        /// A string of data to receive.
        /// </summary>
        public string DataString { get; set; }
        /// <summary>
        /// A message that was received.
        /// </summary>
        public string Message { get; set; }
    }
}
