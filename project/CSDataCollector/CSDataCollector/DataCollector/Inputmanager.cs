using System;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace CSDataCollector.Input
{

    public class InputManager
    {

        private MqttClient Client { get; set; }

        private string[] subjects = new string[4] {"Connection", "Event", "Monitoring", "Position" };

        private byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };

        public InputManager(string _sAddress)
	    {
            Client = new MqttClient(IPAddress.Parse(_sAddress));
            Client.Connect(Guid.NewGuid().ToString());


            Client.Subscribe(subjects, qosLevels);

            Client.MqttMsgPublishReceived += MessageReceived;
	    }

        public void MessageReceived(object sender, MqttMsgPublishEventArgs e)
        {
            throw new NotImplementedException();
        }



    }
}
