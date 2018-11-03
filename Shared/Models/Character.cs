namespace PokemonShared.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterClass[] Classes { get; set; }
        public Specifications[] Specifications { get; set; }
        public Ranking Ranking { get; set; }
		public string ImageFile { get; set; }

		public Character() { }

		public Character(int id, string name, Ranking ranking, 
                        CharacterClass[] classes, string imageFile, 
                        Specifications[] specifications) {
			this.Id = id;
			this.Name = name;
			this.Ranking = ranking;
			this.Classes = classes;
            this.ImageFile = imageFile;
            this.Specifications = specifications;

        }

    }
}