using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandParser
{
    class KeyValue : Command
    {
        readonly Dictionary<string, string> _mPairs;
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

        public override void AddValue(string text)
        {
            string key;
            string value;

            if (IsPairFilled())
            {
                key = _mPairs.Last().Key;
                value = text;
                _mPairs.Remove(_mPairs.Last().Key);
            }
            else
            {
                key = text;
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
