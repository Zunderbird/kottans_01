using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    class Print : Command
    {
        private string m_text;

        public override void Execute()
        {
            Console.WriteLine(m_text);
        }

        public override void AddValue(string i_str)
        {
            if (m_text != null) m_text += " ";

            m_text += i_str;
        }
    }
}
