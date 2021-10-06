using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {            
            // Following is a client subscriber to a topic :
            // create client instance
            // subscribtion is done to a public MQTT broker
            MqttClient client = new MqttClient("broker.hivemq.com", 1883, false, null, null, MqttSslProtocols.TLSv1_2);

            // register to message received
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to all topics under Joud/home "Joud/home/#" with QoS 2 -- we can also listen to /Joud/home/temperature
            client.Subscribe(new string[] { "/Joud/home/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // handle message received            
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            string message = JsonConvert.SerializeObject(ReceivedMessage);
            List<String> sensorMessages = new List<string>();
            sensorMessages.Add(message);
            //string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            //File.AppendAllText(@"TemperatureSensorData1.txt", ReceivedMessage);
            //File.AppendAllText(@"TemperatureSensorData1.txt", "\n");
            File.AppendAllLines(@"TemperatureSensorData2.txt", sensorMessages); // appending the incoming payload to a file - it is saved under ../IIoT/MQTTSubscriber/bin/Debug/net5.0
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(ReceivedMessage);
             
        }
    }
    
}
