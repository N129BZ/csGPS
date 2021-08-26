# csGPS - output NMEA sentences from Ublox USB GPS receiver to the console
Ublox GPS usb dongle contol in a C# console app, written in .NET Core on Ubuntu Linux.  Adapted from Stratux file gps.go. NOTE: I have not been successful running this on Windows 10, and I don't have the patience to mess around with all of the B.S. dealing with dependencies and versions on Windows. If someone wants to try, good luck. It's ironic that a MS product like .NET Core works great on Linux but is a royal PITA on the mother ship.

Will run either of 2 ways:

  1. Call "dotnet run csGPS" and use a valid csGPSconfig.json file with portname and baudrate values:
  ```
       {
          "serialport": {
          "portname": "/dev/ttyACM0",
          "baudrate": 9600
          }
       }
  ```
  
  2. Call "dotnet run csGPS" and pass the 2 value arguments (order doesn't matter)
  ```
       dotnet run csGPS /dev/ttyACM0 9600
       dotnet run csGPS 115200 /dev/ttyACM0
  ```

Dependencies:
  ```
      Newtonsoft.Json Version 13.0.1
      System.IO.Ports Version 5.0.1
      System.Management Version 5.0.0   
  ```
