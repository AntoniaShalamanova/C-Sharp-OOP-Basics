using WildFarm.Animals.Mammals;

namespace WildFarm.Animals.Felines
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public override string ToString()
        {
            return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }
    }
}
