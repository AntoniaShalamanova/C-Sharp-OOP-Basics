using CommandPattern.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICommand command;

        public string Read(string[] input)
        {
            string action = input[0].ToLower();
            input = input.Skip(1).ToArray();

            switch (action)
            {
                case "shutdown":
                    command = new ShutdownCommand(input);
                    break;

                case "restart":
                    command = new RestartCommand(input);
                    break;

                case "hibernate":
                    command = new HibernateCommand(input);
                    break;

                case "abort":
                    command = new AbortCommand();
                    break;

                case "exit":
                    command = new ExitCommand();
                    break; ;

                default:
                    break;
            }

            if (command == null)
            {
                throw new ArgumentNullException("Invalid command!");
            }

            string result = command.Execute();

            return result;
        }
    }
}
