using System;
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
        private string[] subjects = new string[4] {"Connection", "Event", "Monitoring", "POSITIONS" };

        /// <summary>
        /// The levels for the subscription.
        /// </summary>
        private byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };



        /// <summary>
        /// The inputManager, this class manages the connection to the broker.
        /// </summary>
        /// <param name="_sAddress"></param>
        public InputManager(string _sAddress)
	    {
            // initialize the parser.
            parser = new DataParser();

            // setup of the client.
            Client = new MqttClient(_sAddress, 16258, false, null, MqttSslProtocols.None);
            Client.ConnectionClosed += Client_ConnectionClosed;
            Client.MqttMsgSubscribed += Client_MqttMsgSubscribed;
            Client.MqttMsgPublishReceived += MessageReceived;
            Client.ProtocolVersion = MqttProtocolVersion.Version_3_1_1;
            byte response = Client.Connect(Guid.NewGuid().ToString(), "niels", "12345");
            
            // check if the connection is made else print the problem and return.
            if (Client.IsConnected)
            {
                Connected = true;
            }
            else
            {
                Console.WriteLine("The connection is not made, the return code is : " + response);
                return;
            }
            Client.Subscribe(subjects, qosLevels);


	    }

        private void Client_ConnectionClosed(object sender, EventArgs e)
        {
            Connected = false;
        }

        private void Client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine("we are subscribed");
            Console.WriteLine(e.ToString());
        }


        /// <summary>
        /// The event for incoming messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MessageReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine("The message is received : " + e.Topic);
            parser.ParseData(e.Message, e.Topic);
        }


    }
}
