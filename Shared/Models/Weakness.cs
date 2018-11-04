namespace PokemonShared.Models
{
    public class Weakness
    {
        public string ClassName { get; set; }
        public decimal Ratio { get; set; }

        public Weakness() { }

        public Weakness(string className, decimal ratio)
        {
            this.ClassName = className;
            this.Ratio = ratio;
        }

    }
}
