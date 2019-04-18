using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    public class Car
    {
        private const string offset = "  ";

        private string model;
        private Engine engine;
        private string weight;
        private string color;

        public static Car MakeCar(string[] parameters, List<Engine> engines)
        {
            string model = parameters[0];
            string engineModel = parameters[1];

            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            Car car = new Car(model, engine);

            if (parameters.Length == 3 && int.TryParse(parameters[2], out int result))
            {
                car.Weight = parameters[2];
            }
            else if (parameters.Length == 3)
            {
                car.Color = parameters[2];
            }
            else if (parameters.Length == 4)
            {
                car.Weight = parameters[2];
                car.Color = parameters[3];
            }

            return car;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:\n", this.Model);
            sb.Append(this.Engine.ToString());
            sb.AppendFormat("{0}Weight: {1}\n", offset, this.Weight);
            sb.AppendFormat("{0}Color: {1}", offset, this.Color);

            return sb.ToString();
        }
    }
}

