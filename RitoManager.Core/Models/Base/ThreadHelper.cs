using System.Threading;

namespace ServerControl.Core
{
    /// <summary>
    /// A helper class for managing and creating threads
    /// </summary>
    public static class ThreadHelper
    {
        /// <summary>
        /// A helper function to set up a thread
        /// </summary>
        /// <param name="thread">The thread to set up</param>
        /// <param name="ThreadedFunction">The function to execute on the thread</param>
        /// <param name="IsBackground">To set the thread as a background thread</param>
        /// <param name="ThreadName">The name of the thread</param>
        /// <returns></returns>
        public static void SetupThread(this Thread thread, ThreadStart ThreadedFunction, string ThreadName = "", bool IsBackground = true)
        {
            // Create the thread to execute the function
            thread = new Thread(ThreadedFunction);

            // Set parameters of the thread
            thread.IsBackground = IsBackground;
            thread.Name = ThreadName;

            // Start the thread
            thread.Start();
        }
    }
}
