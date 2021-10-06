using System;
using System.IO;
using System.Text;
using AppKit;
using Foundation;
using Newtonsoft.Json;

namespace cocoApp
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void btnShowData_Click(NSObject sender)
        {
            //throw new NotImplementedException();            
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("/Users/joud/Projects/cocoApp/TemperatureSensorData2.txt");
            while ((line = file.ReadLine()) != null)
            {
                txtTemperatureData.StringValue = line;
                string message = JsonConvert.SerializeObject(line);
                //message = message.Replace("\\\\\\","\\");
                //message = message.Replace("\\\\n", "\\n");
                //message = message.TrimStart(Convert.ToChar("\\")).TrimEnd(Convert.ToChar("\\"));
                //message = message.TrimStart(Convert.ToChar("\"")).TrimEnd(Convert.ToChar("\""));                
                //message = message.Remove(message.Length - 1, 1) + "\\\"";
                //message = message.TrimStart(Convert.ToChar("\\")).TrimEnd(Convert.ToChar("\\"));
                //message = message.TrimStart(Convert.ToChar("\"")).TrimEnd(Convert.ToChar("\""));
                //message = message.TrimEnd(Convert.ToChar("\\"));
                //message = message.TrimStart(Convert.ToChar("{"));
                //message = message.TrimStart(Convert.ToChar("\\"));
                //message = message.TrimEnd(Convert.ToChar("}"));
                //message = message.TrimStart(Convert.ToChar("n"));
                //message = message.Replace("\\n", " ");
                //message = "{" + message + "}";

                Console.WriteLine(message);

                message = "{\n  \"name\": \"room1/temperature\",\n  \"deviceEUI\": \"123ABC\",\n  \"port\": \"3\",\n  \"timestamp\": \"2021-10-06T11:36:45.272462+02:00\",\n  \"value\": 12,\n  \"unit\": \"C\"\n}";
                Sensor Sensorline = JsonConvert.DeserializeObject<Sensor>(message);
            
                txtName.StringValue = "123ABC";
                txtType.StringValue = "Temperature";
                txtUnit.StringValue = "Celcius";
                             
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

