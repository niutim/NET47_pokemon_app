using PokemonShared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PokemonBackEnd.Controllers
{
    public class CharactersController : ApiController
    {

		private static Character[] characters =
		{
			new Character(1, "Pikachu", 1, 100, new string[] { "Electricity" }, "pikachu.png", 
                          new Specifications(40, 6000, 35, 55, 40, 50, 50, 90), 
                          new Weakness[] { new Weakness("Electricity",0.5m), new Weakness("Earth",2), new Weakness("Fly", 0.5m), new Weakness("Steel", 0.5m) } ),
            new Character(2, "Salameche", 2, 99, new string[] { "Fire" }, "salameche.png", 
                        new Specifications(60, 9000, 39, 52, 43, 60, 50, 65), 
                        new Weakness[] { new Weakness("Fire", 0.5m), new Weakness("Earth", 2m), new Weakness("Rock", 2m), new Weakness("Water", 2m) } ),
			new Character(3, "BulleBizarre", 5, 80, new string[] { "Plant", "Poison" }, "bulbasaur.jpg",
                        new Specifications(70, 7000, 45, 49, 49, 65, 65, 45),
                        new Weakness[] { new Weakness("Fight", 0.5m), new Weakness("Fly", 2m), new Weakness("Fire", 2m) } ),
            new Character(4, "Florizarre", 6, 33, new string[] { "Plant", "Poison" }, "venusaur.png",
                        new Specifications(200, 100000, 80, 82, 83, 100, 100, 80),
                        new Weakness[] { new Weakness("Fight", 2m), new Weakness("Fire", 2m), new Weakness("Psy", 2m), new Weakness("Ice", 2m) } ),
            new Character(5, "Dracaufeu", 3, 90,  new string[] { "Fire", "Fly" }, "dracaufeu.png", 
                        new Specifications(170, 91000, 78, 84, 78, 109, 85, 100), 
                        new Weakness[] { new Weakness("Rock", 4m), new Weakness("Water", 2m), new Weakness("Electricity", 2m) } ),
            new Character(6, "Carapuce", 4, 89, new string[] { "Water" }, "carapuce.png", 
                        new Specifications(50, 8500, 44, 48, 65, 50, 64, 43), 
                        new Weakness[] { new Weakness("Plant", 2m), new Weakness("Electricity", 2m) } ),
            new Character(7, "Aspicot", 7, 30, new string[] { "Insect", "Poison" }, "aspicot.png", 
                        new Specifications(30, 3200, 40, 35, 30, 20, 20, 50), 
                        new Weakness[] { new Weakness("Fly", 2m), new Weakness("Rock", 2m), new Weakness("Fire", 2m), new Weakness("Psy", 2m) } ),
            new Character(8, "Sabelette", 8, 28, new string[] { "Earth" }, "sabelette.png", 
                        new Specifications(60, 12000, 50, 75, 85, 20, 30, 40), 
                        new Weakness[] { new Weakness("Water", 2m), new Weakness("Plant", 2m), new Weakness("Ice", 2m) } ),
            new Character(9, "Feunard", 9, 25,  new string[] { "Fire" }, "feunard.png", 
                        new Specifications(110, 19900, 73, 76, 75, 81, 100, 100), 
                        new Weakness[] { new Weakness("Earth", 2m), new Weakness("Rock", 2m), new Weakness("Water", 2m) } ),
            new Character(10, "Abra", 10, 20, new string[] { "Psy" }, "abra.png", 
                        new Specifications(90, 19500, 25, 20, 15, 105, 55, 90), 
                        new Weakness[] { new Weakness("Insect", 2m), new Weakness("Ghost", 2m), new Weakness("Darkness", 2m) } ),
            new Character(11, "Racaillou", 11, 10, new string[] { "Earth", "Rock" }, "racaillou.png", 
                        new Specifications(40, 20000, 40, 80, 100, 30, 30, 20), 
                        new Weakness[] { new Weakness("Plant", 4m), new Weakness("Water", 2m), new Weakness("Steel", 2m), new Weakness("Water", 4m) } ),
            new Character(12, "Grolem", 12, 5, new string[] { "Earth", "Rock" }, "grolem.png", 
                        new Specifications(140, 300000, 80, 120, 130, 55, 65, 45), 
                        new Weakness[] { new Weakness("Water", 4m), new Weakness("Plant", 4m), new Weakness("Ice", 4m), new Weakness("Steel", 4m) } )
        };

        public IEnumerable<Character> GetAllCharacters()
        {
            return characters;
        }

        [Route("api/characters/id/{id}")]
        public IHttpActionResult GetCharacterById(int id)
        {
            List<Character> listCharacters = PokemonDataStore.Adapters.CharacterAdapter.GetCharacters();
            if (listCharacters.Count != 0) characters = listCharacters.ToArray();

            var character = characters.FirstOrDefault((p) => p.Id == id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        [Route("api/characters/name/{name}")]
        public IHttpActionResult GetCharacterByName(string name)
        {
            List<Character> listCharacters = PokemonDataStore.Adapters.CharacterAdapter.GetCharacters();
            if (listCharacters.Count != 0) characters = listCharacters.ToArray();

            var character = characters.FirstOrDefault((p) => p.Name.ToLower().Contains(name.ToLower()));
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        [Route("api/characters/contains/{searchString}")]
        public IHttpActionResult GetCharactersContainingString(string searchString)
        {

            List<Character> listCharacters = PokemonDataStore.Adapters.CharacterAdapter.GetCharacters();
            if (listCharacters.Count != 0) characters = listCharacters.ToArray();

            var character = characters.ToList().FindAll((p) => p.Name.ToLower().Contains(searchString.ToLower()));
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character.ToArray<Character>());
        }

        [Route("api/characters/top/{count}")]
        public IHttpActionResult GetTopXXCharacters(int count)
        {
            List<Character> listCharacters = PokemonDataStore.Adapters.CharacterAdapter.GetCharacters();
            if (listCharacters.Count != 0) characters = listCharacters.ToArray();

            var firstTenCharacters = characters.ToList<Character>().OrderByDescending(c => c.Votes).ToArray<Character>().Take<Character>(count).ToArray<Character>();
            if (firstTenCharacters == null)
            {
                return NotFound();
            }
            return Ok(firstTenCharacters);
        }

        [Route("api/characters/vote/{charId}")]
        public IHttpActionResult GetVoteForCharacter(long charId)
		{
            List<Character> listCharacters = PokemonDataStore.Adapters.CharacterAdapter.GetCharacters();
            if (listCharacters.Count != 0) characters = listCharacters.ToArray();

            var character = characters.First<Character>(c => c.Id == charId);
            if (character == null)
            {
                return NotFound();
            }
            else
            {
                character.Votes++;
                listCharacters = characters.ToList<Character>().OrderByDescending(c => c.Votes).ToList<Character>();
                for (int cpt=0; cpt< listCharacters.Count;cpt++)
                {
                    listCharacters[cpt].Rank = cpt + 1;
                }
            }
			return Ok(character);
		}

		
	}
}
