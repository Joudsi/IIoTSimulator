using System;
using System.Text;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;


namespace MQTTPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Following is a client publisher to a topic :
            // create client instance
            // connection is done to a publich MQTT broker
            MqttClient client = new MqttClient("broker.hivemq.com", 1883, false, null, null, MqttSslProtocols.TLSv1_2);

            // create a user id
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // creating a payload opject for the temperature sensor
            Sensor temperatureSensor = new Sensor
            {
                name = "room1/temperature",
                deviceEUI = "123ABC",
                port = "3",
                timestamp = DateTimeOffset.Now,
                value = 0,
                unit = "C"

            };

            // publish a message on "/Joud/home/temperature" topic with QoS 2
            while (true)
            {
                try
                {
                    int randomValue = new Random().Next(9, 17); //random value as a temperature value simulator
                    temperatureSensor.value = randomValue;
                    temperatureSensor.timestamp = DateTimeOffset.Now;
                    string tempSemsorJson = JsonConvert.SerializeObject(temperatureSensor, Formatting.Indented);
                    Console.WriteLine(tempSemsorJson);

                    client.Publish("/Joud/home/temperature", Encoding.UTF8.GetBytes(tempSemsorJson), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Unexpected Exception {ex.Message}");
                    Console.WriteLine($"\t{ex.ToString()}");
                }
            }
        }

    }

    class Sensor
    {
        public string name { get; set; }
        public string deviceEUI { get; set; }
        public string port { get; set; }
        public System.DateTimeOffset timestamp { get; set; }
        public int value { get; set; }
        public string unit { get; set; }
    }
}