using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //shutdown 30 -> minutes
            //restart 30
            //hibernate 30
            //abort
            //exit

            //Engine -> Run
            //CommandParser/CommandInterpreter
            //CommandPattern

            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
