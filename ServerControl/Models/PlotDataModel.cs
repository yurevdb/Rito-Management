using System;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using TransmissionControl;

namespace ServerControl
{
    public static class PlotDataModel
    {
        #region Public Variables

        /// <summary>
        /// Connection to the server via tcp for server statistics
        /// </summary>
        public static DataSender serverStats;
        /// <summary>
        /// Connection to the server via ssl
        /// </summary>
        public static SslSender conn;
        /// <summary>
        /// Thread to receive the server statistics
        /// </summary>
        public static Thread dataReceiver;
        /// <summary>
        /// Thread to receive tcp server messages
        /// </summary>
        public static Thread listener;
        
        #endregion

        #region Private Variables

        /// <summary>
        /// The port on the server from where the server statistics come
        /// </summary>
        private const int SERVER_STATS_PORT = 5000;
        /// <summary>
        /// The port on the server for the tcp messages
        /// </summary>
        private const int SERVER_TCP_PORT = 5555;
        /// <summary>
        /// The port on the server for the ssl messages
        /// </summary>
        private const int SERVER_SSL_PORT = 5005;
        /// <summary>
        /// The name of the server
        /// </summary>
        private const string SERVER_NAME = "Rito";

        #endregion

        #region Public Functions

        /// <summary>
        /// Setting up the plot models to receive data from the server and display that info
        /// </summary>
        public static async Task SetupPlotmodels()
        {
            Action act = () => SetUpPlots();
            await Task.Run(act);
            WindowViewModelHelper.SetStatusText(Status.Ready);
            return;
        }

        /// <summary>
        /// Connecting to the server to receive server statistics and setting up the thread to receive those statistics.
        /// </summary>
        private static void SetUpPlots()
        {
            WindowViewModelHelper.SetStatusText(Status.Connecting);
            // Make connection to the server to receive the stats
            do
            {
                try
                {
                    serverStats = new DataSender(SERVER_NAME, SERVER_STATS_PORT);
                }
                catch(SocketException)
                {
                    for (int i = 30; i > 0; i--)
                    {
                        WindowViewModelHelper.SetStatusText($"Host not online. Reconnecting in {i} seconds.");
                        Thread.Sleep(1000);
                    }
                    WindowViewModelHelper.SetStatusText(Status.Connecting);
                }

            } while (serverStats == null);

            // After creating the connection, Set up a seperate thread to constantly receive data from the server
            WindowViewModelHelper.SetStatusText("Setting up threads...");
            dataReceiver.SetupThread(() => serverStats.ReceiveServerData(), "Server stats reciever");

        }

        #endregion
    }
}
