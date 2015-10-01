using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandParser
{
    public static class CommandParser
    {
        public static void ExecuteCommands(string[] args)
        {
            var commands = Parse(args);

            foreach (var command in commands)
            {
                command.Execute();
            }
        }

        private static List<Command> Parse(string[] args)
        {
            var commands = new List<Command>();

            if (args.Length == 0) commands.Add(new Help());

            foreach (var commandStr in args)
            {
                switch (commandStr)
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
                            commands.Last().AddValue(commandStr);
                        else
                            Console.WriteLine("Command <{0}> is not supported, use CommandParser.exe /? to see set of allowed commands", commandStr);
                        break;
                }
            }
            return commands;
        }
    }
}
