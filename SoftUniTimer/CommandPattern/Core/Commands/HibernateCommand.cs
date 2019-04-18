using CommandPattern.Core.Contracts;
using CommandPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class HibernateCommand : ICommand
    {
        private string[] input;

        public HibernateCommand(string[] input)
        {
            this.input = input;
        }

        public string Execute()
        {
            if (this.input.Length < 1 || string.IsNullOrEmpty(this.input[0]))
            {
                throw new ArgumentNullException("Parameters count mismatch!");
            }

            int minutes = int.Parse(this.input[0]);
            int seconds = minutes.ToSeconds();

            Process.Start("shutdown", $"/h /t {seconds}");

            return $"Windows will hibernate after {minutes} minutes!";
        }
    }
}
