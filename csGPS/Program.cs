﻿using System;
using System.Threading;

namespace csGPS
{
    
    class Program
    {
        public static void Main(string[] args)
        {
            string port = "/dev/ttyACM0";

            SerialReader reader = new SerialReader(port);
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
 