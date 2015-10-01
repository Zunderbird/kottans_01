using System;

namespace CommandParser
{
    class Ping : Command
    {
        public override void Execute()
        {
            Console.WriteLine("Pinging...");
            Console.Beep(500, 1000);
        }
        public override void AddValue(string str)
        {
        }
    }
}
