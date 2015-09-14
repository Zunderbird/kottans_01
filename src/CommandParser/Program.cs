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
            List<Command> commands = Parse(args);

            foreach (Command command in commands)
            {
                command.Execute();
            }
        }

        static List<Command> Parse(string[] i_args)
        {
            var commands = new List<Command>();

            if (i_args.Length == 0) commands.Add(new Help());

            for (int i = 0; i < i_args.Length; i++)
            {
                switch (i_args[i].ToString())
                {
                    case "/?":
                    case "/help":
                    case "-help":
                        commands.Clear();
                        commands.Add(new Help());
                        return commands;
                    case "-k":
                        commands.Add(new KeyValue());
                        break;
                    case "-ping":
                        commands.Add(new Ping());
                        break;
                    case "-print":
                        commands.Add(new Print());
                        break;
                    default:
                        if (commands.Count > 0 && !(commands.Last() is Ping))
                            commands.Last().AddValue(i_args[i].ToString());
                        else
                            Console.WriteLine("Command <{0}> is not supported, use CommandParser.exe /? to see set of allowed commands", i_args[i].ToString());
                        break;
                }
            }
            return commands;
        }
    }

}
