using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentGolf
{
    class LogEntry
    {
        public string PlayerName { get; set; }
        public int Swing { get; set; }
        public double StrokeLength { get; set; }

        public LogEntry()
        {
        }

        public LogEntry(string _name, int _swing, double _strokeLength)
        {
            PlayerName = _name;
            Swing = _swing;
            StrokeLength = _strokeLength;
        }

        public static void PrintLog(List<LogEntry> newLog)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=================================================================");           
            Console.WriteLine(newLog[0].PlayerName);
            Console.WriteLine("=================================================================");
            Console.ForegroundColor = ConsoleColor.Gray;

            foreach (LogEntry logEntry in newLog)
            {
                Console.WriteLine($"Stroke no: {logEntry.Swing:0.##} | Stroke length: {logEntry.StrokeLength:0.##}");
            }
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
    }

    
}
