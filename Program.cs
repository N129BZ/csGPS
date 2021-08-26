using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace csGPS 
{    
    class Program 
    {
        public static void Main(string[] args) 
        {
            int baudrate = 0; 
            string port = ""; 
            bool hasArgs = false; // used to test for either args or csGPSconfig file

            if (args.Length > 0) {  
                // in Linux even if no args were passed, there will be a "csGPS" arg :/
                // so we'll iterate and check for valid arg(s)
                foreach (string s in args) {
                    if (s.Length > 0 ) {
                        if (int.TryParse(s, out int testint)) {
                            baudrate = testint;
                            hasArgs = true;
                        }
                        else if (s.Contains("/dev")) {
                            port = s;
                            hasArgs = true;
                        }
                    }
                }
            }

            // if no valid args were found, read the csGPSconfig.json file
            if (!hasArgs) {
                try {
                    JObject jo = JObject.Parse(File.ReadAllText("./csGPSconfig.json"));
                    port = (string)jo["csGPS_Configuration"]["serialport"]["portname"];
                    baudrate = (int)jo["csGPS_Configuration"]["serialport"]["baudrate"];
                }
                catch (System.IO.FileNotFoundException) {
                    Console.WriteLine("No csGPSconfig.json file and no args! Exiting.");
                    return;   
                }
                catch (Newtonsoft.Json.JsonReaderException) {
                    Console.WriteLine("Bad value(s) in csGPSconfig.json. Exiting.");
                    return;
                }
            }

            SerialReader reader = new SerialReader(port, baudrate);
            Thread readerThread = new Thread(new ThreadStart(reader.Run));

            reader.OnDataReceived += OnDataReceived;
            readerThread.Start();

            // Pressing any key will stop the application
            Console.ReadLine();

            reader.Stop();
            readerThread = null;
            reader = null;
        }

        private static void OnDataReceived(object sender, SerialData data) {
            Console.WriteLine(data.Sentence);
        }
    }
}
 
