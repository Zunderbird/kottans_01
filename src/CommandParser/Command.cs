using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    abstract class Command
    {
        public abstract void Execute();
        public abstract void AddValue(string i_str);
    }
}
