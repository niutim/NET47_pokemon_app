namespace PokemonShared.Models
{
    public class Weakness
    {
        public long CharacterId { get; set; }
        public long ClassId { get; set; }
        public decimal Ratio { get; set; }

        public Weakness() { }

        public Weakness(long characterId, long classId, decimal ratio)
        {
            this.CharacterId = characterId;
            this.ClassId = classId;
            this.Ratio = ratio;
        }

    }
}
