using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    class Ping : Command
    {
        public override void Execute()
        {
            Console.WriteLine("Pinging...");
            Console.Beep(500, 1000);
        }
        public override void AddValue(string i_str)
        {
        }
    }
}
