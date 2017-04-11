using System;
using System.Net.Sockets;
using System.Text;

namespace TransmissionControl
{
    public class DataSender : IDisposable
    {
        #region Private Members

        /// <summary>
        /// The response data from the server.
        /// </summary>
        private string responseData;

        /// <summary>
        /// The Cpu usage percent received from the server.
        /// </summary>
        private double CpuPercentOfUse;

        /// <summary>
        /// The Ram usage percent received from the server.
        /// </summary>
        private double RamPercentOfUse;

        /// <summary>
        /// The amount of Kb sent per second
        /// </summary>
        private double NetworkSentAmount;

        /// <summary>
        /// The amount of Kb received per second
        /// </summary>
        private double NetworkReceivedAmount;

        /// <summary>
        /// The tcp client
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// The tcp stream
        /// </summary>
        private NetworkStream stream;

        /// <summary>
        /// The byte array of data to send
        /// </summary>
        private Byte[] data;

        #endregion

        #region Public Properties/Events

        /// <summary>
        /// A <see cref="bool"/> that represents if the connection is active.
        /// </summary>
        public bool ConnectionUp { get; private set; }

        /// <summary>
        /// An <see cref="event"/> that is triggered when server data is available.
        /// </summary>
        public event EventHandler<ReceivedDataEventArgs> ServerDataAvailable;

        /// <summary>
        /// An <see cref="event"/> that is triggered when a server message is received.
        /// </summary>
        public event EventHandler<ReceivedDataEventArgs> ServerMessageReceived;

        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="Host">The name of the server to make a connection with.</param>
        /// <param name="Hostport">The port on the server to connect to.</param>
        /// <exception cref="SocketException">An exception thrown when theres a problem with the connection.</exception>
        public DataSender(string Host, int Hostport)
        {
            try
            {
                client = new TcpClient(Host, Hostport);
                stream = client.GetStream();
                ConnectionUp = true;
            }
            catch (SocketException ex)
            {
                ConnectionUp = false;
                throw new SocketException(ex.ErrorCode);
            }

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The Function to send data to the server.
        /// </summary>
        /// <param name="data">The data to send.</param>
        public void SendData(string data)
        {
            this.data = Encoding.ASCII.GetBytes(data);
            stream.Write(this.data, 0, this.data.Length);
            stream.Flush();
        }

        /// <summary>
        /// The Function that will operate on a seperate thread to receive server statistics data.
        /// Makes use of a while(true) and fire an <see cref="event"/> when data is received.
        /// </summary>
        public void ReceiveServerData()
        {
            while (true)
            {
                double[] temp = new double[4];
                responseData = string.Empty;
                CpuPercentOfUse = double.NaN;
                RamPercentOfUse = double.NaN;
                NetworkSentAmount = double.NaN;
                NetworkReceivedAmount = double.NaN;
                Byte[] receivedata = new Byte[256];
                Int32 bytes;
                try
                {
                    bytes = stream.Read(receivedata, 0, receivedata.Length);
                }
                catch
                {
                    break;
                }
                responseData = Encoding.ASCII.GetString(receivedata, 0, bytes);
                string[] totalData = responseData.Split(';');
                try
                {
                    CpuPercentOfUse = Convert.ToDouble(totalData[0].Replace('.', ','));
                }
                catch
                {
                    if (totalData[0] != "")
                    {
                        string[] s = totalData[0].Split('.');
                        CpuPercentOfUse = Convert.ToDouble(s[0] + "," + s[1]);
                    }
                    else
                        break;
                }
                try
                {
                    RamPercentOfUse = Convert.ToDouble(totalData[1].Replace('.', ','));
                }
                catch
                {
                    string[] s = totalData[1].Split('.');
                    RamPercentOfUse = Convert.ToDouble(s[0] + "," + s[1]);
                }
                try
                {
                    NetworkSentAmount = Convert.ToDouble(totalData[2].Replace('.', ','));
                }
                catch
                {
                    string[] s = totalData[2].Split('.');
                    NetworkSentAmount = Convert.ToDouble(s[0] + "," + s[1]);
                }
                try
                {
                    NetworkReceivedAmount = Convert.ToDouble(totalData[3].Replace('.', ','));
                }
                catch
                {
                    string[] s = totalData[3].Split('.');
                    NetworkReceivedAmount = Convert.ToDouble(s[0] + "," + s[1]);
                }
                temp[0] = CpuPercentOfUse;
                temp[1] = RamPercentOfUse;
                temp[2] = NetworkSentAmount;
                temp[3] = NetworkReceivedAmount;
                ServerDataAvailable(this, new ReceivedDataEventArgs() { Data = temp });
            }
        }

        /// <summary>
        /// The Function that will operate on a seperate thread to receive data.
        /// Makes use of a while(true) and fire an <see cref="event"/> when data is received.
        /// </summary>
        public void ReceiveData()
        {
            while (true)
            {
                responseData = string.Empty;
                Byte[] receivedata = new Byte[256];
                Int32 bytes = stream.Read(receivedata, 0, receivedata.Length);
                responseData += Encoding.ASCII.GetString(receivedata, 0, bytes) + "\n";
                if (responseData != "\n")
                    ServerMessageReceived(this, new ReceivedDataEventArgs() { Message = responseData });
            }
        }

        /// <summary>
        /// Function that closes the connection.
        /// </summary>
        public void CloseConnection()
        {
            ConnectionUp = false;
            stream.Close();
        }

        /// <summary>
        /// Function to dispose of the object.
        /// </summary>
        public void Dispose()
        {
            stream.Close();
            ConnectionUp = false;
            stream = null;
            client = null;
        }

        #endregion
    }
}
