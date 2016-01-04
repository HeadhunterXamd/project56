using System;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace CSDataCollector.Input
{

    public class InputManager
    {

        /// <summary>
        /// The client which connects with the broker.
        /// </summary>
        private MqttClient Client { get; set; }
        
        /// <summary>
        /// The data parser this will be used to parse the incoming data.
        /// </summary> 
        private DataParser parser { get; set; }

        /// <summary>
        /// Set the connected bool as flag for if the connection is enabled.
        /// </summary>
        public bool Connected { get; private set; }

        /// <summary>
        /// The subjects we will subscribe to.
        /// </summary>
        private string[] subjects = new string[4] {"CONNECTIONS", "EVENTS", "MONITORING", "POSITIONS" };

        /// <summary>
        /// The levels for the subscription.
        /// </summary>
        private byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };

        private DatabaseManagment.DbManager databaseManager { get; set; }

        /// <summary>
        /// The inputManager, this class manages the connection to the broker.
        /// </summary>
        /// <param name="_sAddress"></param>
        public InputManager(string _sAddress)
	    {
            // initialize the parser.
            parser = new DataParser();
            databaseManager = new DatabaseManagment.DbManager();

            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(_sAddress);
                Console.WriteLine(hostEntry);
                string hostname = hostEntry.HostName;
                Client = new MqttClient(hostname, 8883, false, null, null, MqttSslProtocols.None);
            }
            catch (Exception e)
            {
                Program.Log(e.Message);
                Client = new MqttClient(IPAddress.Parse(_sAddress), 8883, false, null, null, MqttSslProtocols.None);
            }

            // setup of the client.
            Client.ConnectionClosed += Client_ConnectionClosed;
            Client.MqttMsgSubscribed += Client_MqttMsgSubscribed;
            Client.MqttMsgPublishReceived += MessageReceived;
            Client.ProtocolVersion = MqttProtocolVersion.Version_3_1_1;
            byte response = Client.Connect(Guid.NewGuid().ToString());
            
            // check if the connection is made else print the problem and return.
            if (Client.IsConnected)
            {
                Connected = true;
                Console.WriteLine("The connection is made " + response);
            }
            else
            {
                Program.Log("The connection is not made, the return code is : " + response);
                return;
            }
            Client.Subscribe(subjects, qosLevels);


	    }

        /// <summary>
        /// if the connection is closed set the boolean.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_ConnectionClosed(object sender, EventArgs e)
        {
            Connected = false;
        }

        /// <summary>
        /// The event received when the subscription has been accepted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Program.Log("The client is subscribed to the broker... \n" + e.ToString());
        }


        /// <summary>
        /// The event for incoming messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MessageReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine(e.Topic);
            parser.ParseData(e.Message, e.Topic);
        }


    }
}
