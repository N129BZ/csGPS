using System;
using System.Threading;

namespace csGPS
{
    
    class Program
    {
        public static void Main(string[] args)
        {
            int baudrate = 9600; // default

            string port = args[0];

            if (args.Length > 1) {
                if (int.TryParse(args[1], out int br)) {
                    baudrate = br;
                }
            }
            
            SerialReader reader = new SerialReader(port, baudrate);
            reader.OnDataReceived += OnDataReceived;
            Thread t = new Thread(new ThreadStart(reader.Run));
            t.Start();

            Console.ReadLine();
            reader.Stop();
            t = null;
            reader = null;
        }

        private static void OnDataReceived(object sender, SerialData data) {
            Console.WriteLine(data.Sentence);
        }
    }
}
 