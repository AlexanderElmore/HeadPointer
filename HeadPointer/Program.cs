using System;
using Windows.Devices.Sensors;

class Program
{
    [STAThread]                     // WinRT prefers an STA main thread on desktop
    static void Main()
    {
        var sensor = OrientationSensor.GetDefault();
        if (sensor is null) { Console.WriteLine("No orientation sensor."); return; }

        sensor.ReportInterval = 16; // ≈60 Hz

        sensor.ReadingChanged += (s, e) =>
        {
            var ts = e.Reading.Timestamp;          // <-- note the .Reading.
            var q = e.Reading.Quaternion;

            Console.WriteLine($"{ts}: {q.X:F3}, {q.Y:F3}, {q.Z:F3}, {q.W:F3}");
        };

        Console.WriteLine("Listening – press Enter to quit.");
        Console.ReadLine();
    }
}