namespace PokemonShared.Models
{
    public class Character
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string[] Classes { get; set; }
        public Weakness[] Weaknesses { get; set; }
        public Specifications Specifications { get; set; }
        public int Rank { get; set; }
        public long Votes { get; set; }
        public string ImageFile { get; set; }

		public Character() { }

		public Character(long id, string name, int rank, long votes, 
                        string[] classes, string imageFile, 
                        Specifications specifications, Weakness[] weaknesses) {
			this.Id = id;
			this.Name = name;
			this.Rank = rank;
            this.Votes = votes;
            this.Classes = classes;
            this.ImageFile = imageFile;
            this.Specifications = specifications;
            this.Weaknesses = weaknesses;

        }

    }
}