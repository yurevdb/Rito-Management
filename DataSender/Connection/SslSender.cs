using System;
using System.Collections;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;

namespace TransmissionControl
{
    /// <summary>
    /// A class that provides an <see cref="SslSender"/> object for creating a secured TCP connection to a server.
    /// </summary>
    public class SslSender: IDisposable
    {
        #region Private Members

        /// <summary>
        /// The data received from a server.
        /// </summary>
        string responseData;

        /// <summary>
        /// The <see cref="TcpClient"/> to secure.
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// The secured stream for the <see cref="TcpClient"/>.
        /// </summary>
        private SslStream stream;

        /// <summary>
        /// The data to send.
        /// </summary>
        private Byte[] data;

        /// <summary>
        /// A <see cref="Hashtable"/> to collect the <see cref="SslPolicyErrors"/>.
        /// </summary>
        private static Hashtable certificateErrors = new Hashtable();

        #endregion

        #region Public Properties / Events

        /// <summary>
        /// A <see cref="bool"/> that represents if the connection is active.
        /// </summary>
        public bool ConnectionUp { get; private set; }

        /// <summary>
        /// An event that fires when an error occurs.
        /// </summary>
        //public event EventHandler<ConnectionErrorEventArgs> ConnectionError;

        /// <summary>
        /// An event that fires when data is received from a <see cref="SslStream"/>.
        /// </summary>
        public event EventHandler<ReceivedDataEventArgs> DataReceived;

        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor to create a secured tcp connection.
        /// </summary>
        /// <param name="Host">The servername to create a secured connection with.</param>
        /// <param name="HostPort">The port on the server to wich you need to make a connection.</param>
        /// <exception cref="SocketException">Fires when the server is not online</exception>
        /// <exception cref="AuthenticationException">Fires when the authentication has failed</exception>
        public SslSender(string Host, int HostPort = 80)
        {
            // Try to create a secured connection to the server
            try
            {
                // Creates a tcp connection.
                client = new TcpClient(Host, HostPort);
                // Tries to create a secure socket layer stream for the tcp connection.
                stream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                // Tries to authenticate as a client to the server.
                stream.AuthenticateAsClient(Host);
                // Sets the connection as active if it was made.
                ConnectionUp = true;
            }
            catch (SocketException)
            {
                // There was a socket connection error.
                // Most likely that the server is not online

                ConnectionUp = false;
                throw new SocketException();
            }
            catch (AuthenticationException)
            {
                // The authentication has failed.
                
                client.Close();
                ConnectionUp = false;
                throw new AuthenticationException();
            }
            catch
            {
                throw new Exception();
            }

        }

        #endregion

        #region Helper Functions

        /// <summary>
        /// Called by the RemoteCertificateValidatorCallback to check if the server is authenticated.
        /// </summary>
        /// <param name="sender">A reference to the object that sends the the validation.</param>
        /// <param name="certificate">The <see cref="X509Certificate"/> to authenticate.</param>
        /// <param name="chain">The <see cref="X509Chain"/>,</param>
        /// <param name="sslPolicyErrors">The <see cref="SslPolicyErrors"/> that can occur.</param>
        /// <returns></returns>
        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            string s = "";
            foreach (var x in chain.ChainElements)
            {
                s += x.Certificate + "\n";
                s += x.Information + "\n";
                var temp = x.ChainElementStatus;
                foreach (var a in temp)
                {
                    s += a.Status + "\n";
                    s += a.StatusInformation + "\n\n";
                }
            }

            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            // Should be replace with
            //ConnectionError(this, new ConnectionErrorEventArgs() { Message = string.Format("Certificate error: {0}\n{1}", sslPolicyErrors, s) });
            MessageBox.Show(string.Format("Certificate error: {0}\n{1}", sslPolicyErrors, s));

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Function to send a message to the server.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void SendData(string message)
        {
            data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }
        
        /// <summary>
        /// Functin to receive data on a seperate thread infinitely.
        /// This contains a while(true).
        /// </summary>
        public void ReceiveData()
        {
            while (true)
            {
                responseData = string.Empty;
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
                responseData += Encoding.ASCII.GetString(receivedata, 0, bytes) + "\n";
                if (responseData != "\n")
                {
                    // Send the received data.
                    DataReceived(this, new ReceivedDataEventArgs() { DataString = responseData });
                }
            }

        }

        /// <summary>
        /// Function that returns the answer wether the login info is correct.
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        public bool GetLoginConfirmation()
        {
            while (true)
            {
                responseData = string.Empty;
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
                responseData += Encoding.ASCII.GetString(receivedata, 0, bytes);
                if (responseData == " true")
                    break;
            }
            return true;
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        public void CloseConnection()
        {
            ConnectionUp = false;
            stream.Close();
        }

        /// <summary>
        /// Dispose of the object.
        /// </summary>
        public void Dispose()
        {
            client = null;
            stream = null;
            stream.Close();
            ConnectionUp = false;
        }

        #endregion
    }
}
