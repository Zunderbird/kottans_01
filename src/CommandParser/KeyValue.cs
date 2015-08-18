using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    class KeyValue : Command
    {
        List<KeyValuePair<string, string>> m_list;
        private const string NULL = "null";

        public KeyValue()
        {
            m_list = new List<KeyValuePair<string, string>>();
        }

        public override void Execute()
        {
            foreach (var _element in m_list)
            {
                Console.WriteLine(_element);
            }
        }

        public override void AddValue(string i_str)
        {
            string _key;
            string _value;

            if (isIncomplete())
            {
                _key = m_list.Last().Key;
                _value = i_str;
                m_list.Remove(m_list.Last());
            }
            else
            {
                _key = i_str;
                _value = NULL;
            }
            m_list.Add(new KeyValuePair<string, string>(_key, _value));
        }

        private bool isIncomplete()
        {
            return m_list.Count > 0 && String.Compare(m_list.Last().Value, NULL) == 0;
        }
    }
}
