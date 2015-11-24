using System;
using System.Net;
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
        /// The subjects we will subscribe to.
        /// </summary>
        private string[] subjects = new string[4] {"Connection", "Event", "Monitoring", "Position" };

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
            parser = new DataParser();
            Client = new MqttClient(IPAddress.Parse(_sAddress));
            Client.Connect(Guid.NewGuid().ToString());

            Client.Subscribe(subjects, qosLevels);

            Client.MqttMsgPublishReceived += MessageReceived;
	    }


        /// <summary>
        /// The event for incoming messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MessageReceived(object sender, MqttMsgPublishEventArgs e)
        {
            parser.ParseData(e.Message);
        }



    }
}
