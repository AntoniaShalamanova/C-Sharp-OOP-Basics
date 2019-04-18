namespace Ferrari
{
    public class Ferrari : IFunctional
    {
        private string driverName;

        public string DriverName
        {
            get { return driverName; }
            set { driverName = value; }
        }

        public Ferrari(string name)
        {
            DriverName = name;
        }

        public string PushTheGas()
        {
            return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"488-Spider/{this.UseBrakes()}/{this.PushTheGas()}/{DriverName}";
        }
    }
}
