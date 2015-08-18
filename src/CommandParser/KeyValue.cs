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
                Console.WriteLine("{0} - {1}", _element.Key, _element.Value);
            }
        }

        public override void AddValue(string i_text)
        {
            string _key;
            string _value;

            if (isPairFilled())
            {
                _key = m_list.Last().Key;
                _value = i_text;
                m_list.Remove(m_list.Last());
            }
            else
            {
                _key = i_text;
                _value = NULL;
            }
            m_list.Add(new KeyValuePair<string, string>(_key, _value));
        }

        private bool isPairFilled()
        {
            return m_list.Count > 0 && String.Compare(m_list.Last().Value, NULL) == 0;
        }
    }
}
