using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    class Print : Command
    {
        private string _mText;

        public override void Execute()
        {
            Console.WriteLine(_mText);
        }

        public override void AddValue(string i_str)
        {
            if (_mText != null) _mText += " ";

            _mText += i_str;
        }
    }
}
