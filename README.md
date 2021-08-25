# csGPS
Ublox GPS usb dongle contol in a C# console app, written in .NET Core on Ubuntu Linux.  Adapted from Stratux file gps.go

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
