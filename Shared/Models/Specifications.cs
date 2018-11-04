namespace PokemonShared.Models
{
    public class Specifications
    {
        public long Height { get; set; }
        public long Weight { get; set; }
        public long LifePoints { get; set; }
        public long Attack { get; set; }
        public long Defense { get; set; }
        public long SpecialAttack { get; set; }
        public long SpecialDefense { get; set; }
        public long Speed { get; set; }

        public Specifications() { }

        public Specifications(long height, long weight, long lifePoints, 
                              long attack, long defense, long specialAttack, 
                              long specialDefense, long speed) {
            this.Height = height;
            this.Weight = weight;
            this.LifePoints = lifePoints;
            this.Attack = attack;
            this.Defense = defense;
            this.SpecialAttack = specialAttack;
            this.SpecialDefense = specialDefense;
            this.Speed = speed;


        }
    }
}