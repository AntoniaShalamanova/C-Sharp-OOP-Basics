using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class AbortCommand : ICommand
    {
        public string Execute()
        {
            Process.Start("shutdown", $"/a");

            return $"Command aborted successfully!";
        }
    }
}
