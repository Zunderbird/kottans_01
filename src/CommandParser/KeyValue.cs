using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    class KeyValue : Command
    {
        Dictionary<string, string> _mPairs;
        private const string NULL = "null";

        public KeyValue()
        {
            _mPairs = new Dictionary<string, string>();
        }

        public override void Execute()
        {
            foreach (var element in _mPairs)
            {
                Console.WriteLine("{0} - {1}", element.Key, element.Value);
            }
        }

        public override void AddValue(string i_text)
        {
            string key;
            string value;

            if (IsPairFilled())
            {
                key = _mPairs.Last().Key;
                value = i_text;
                _mPairs.Remove(_mPairs.Last().Key);
            }
            else
            {
                key = i_text;
                value = NULL;
            }
            _mPairs.Add(key, value);
        }

        private bool IsPairFilled()
        {
            return _mPairs.Count > 0 && String.Compare(_mPairs.Last().Value, NULL) == 0;
        }
    }
}
