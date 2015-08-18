using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Command> _commands = Parse(args);

            foreach (Command _command in _commands)
            {
                _command.Execute();
            }
        }

        static List<Command> Parse(string[] i_args)
        {
            List<Command> _commands = new List<Command>();

            if (i_args.Length == 0) _commands.Add(new Help());

            for (int i = 0; i < i_args.Length; i++)
            {
                switch (i_args[i].ToString())
                {
                    case "/?":
                    case "/help":
                    case "-help":
                        _commands.Clear();
                        _commands.Add(new Help());
                        return _commands;
                    case "-k":
                        _commands.Add(new KeyValue());
                        break;
                    case "-ping":
                        _commands.Add(new Ping());
                        break;
                    case "-print":
                        _commands.Add(new Print());
                        break;
                    default:
                        if (_commands.Count > 0 && !(_commands.Last() is Ping))
                            _commands.Last().AddValue(i_args[i].ToString());
                        else
                            Console.WriteLine("Command <{0}> is not supported, use CommandParser.exe /? to see set of allowed commands", i_args[i].ToString());
                        break;
                }
            }
            return _commands;
        }
    }

}
