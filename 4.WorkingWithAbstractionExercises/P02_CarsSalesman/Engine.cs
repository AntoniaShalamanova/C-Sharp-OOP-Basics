using System;
using System.Collections.Generic;
using System.Text;

namespace Car
{
    public class Engine
    {
        private const string offset = "  ";

        private string model;
        private int power;
        private string displacement;
        private string efficiency;

        public static Engine MakeEngine(string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            Engine engine = new Engine(model, power);

            if (parameters.Length == 3 && int.TryParse(parameters[2], out int result))
            {
                engine.Displacement = parameters[2];
            }
            else if (parameters.Length == 3)
            {
                engine.Efficiency = parameters[2];
            }
            else if (parameters.Length == 4)
            {
                engine.Displacement = parameters[2];
                engine.Efficiency = parameters[3];
            }

            return engine;
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
        public string Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:\n", offset, this.Model);
            sb.AppendFormat("{0}{0}Power: {1}\n", offset, this.Power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.Displacement);
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.Efficiency);

            return sb.ToString();
        }
    }
}
