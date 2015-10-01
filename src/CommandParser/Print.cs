using System;

namespace CommandParser
{
    class Print : Command
    {
        private string _mText;

        public override void Execute()
        {
            Console.WriteLine(_mText);
        }

        public override void AddValue(string str)
        {
            if (_mText != null) _mText += " ";
            _mText += str;
        }
    }
}
