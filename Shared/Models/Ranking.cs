namespace PokemonShared.Models
{
    public class Ranking
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public long Votes { get; set; }
    }
}