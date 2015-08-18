using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    class Help : Command
    {
        public override void Execute()
        {
            Console.WriteLine("/?, /help, -help \t Provides Help information for CommandParser");
            Console.WriteLine("-k [key value] \t\t Displays a table of key-value");
            Console.WriteLine("-ping \t\t\t Pinging");
            Console.WriteLine("-print <message> \t Print a message");
        }
        public override void AddValue(string i_str)
        {
        }
    }
}
