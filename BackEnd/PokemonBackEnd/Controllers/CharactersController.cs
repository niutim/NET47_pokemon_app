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
                          new Specifications(40,6,35,55,40,50,50,90), 
                          new Weakness[] { new Weakness("Electricity",0.5m), new Weakness("Earth",2), new Weakness("Fly", 0.5m), new Weakness("Steel", 0.5m) } ),
            new Character(2, "Salameche", 2, 99, new string[] { "Fire" }, "salameche.png", new Specifications(), new Weakness[] { new Weakness() } ),
			new Character(3, "BulleBizarre", 5, 80, new string[] { "Earth" }, "bulbasaur.jpg", new Specifications(), new Weakness[] { new Weakness() } ),
            new Character(4, "Florizarre", 6, 33, new string[] { "Water" }, "venusaur.png", new Specifications(), new Weakness[] { new Weakness() } ),
            new Character(5, "Dracaufeu", 3, 90,  new string[] { "Fire", "Fly" }, "dracaufeu.png", new Specifications(), new Weakness[] { new Weakness() } ),
            new Character(6, "Carapuce", 4, 89, new string[] { "Water" }, "carapuce.png", new Specifications(), new Weakness[] { new Weakness() } ),
            new Character(7, "Aspicot", 7, 30, new string[] { "Insect", "Poison" }, "aspicot.png", new Specifications(), new Weakness[] { new Weakness() } ),
            new Character(8, "Sabelette", 8, 28, new string[] { "Earth" }, "sabelette.png", new Specifications(), new Weakness[] { new Weakness() } ),
            new Character(9, "Feunard", 9, 25,  new string[] { "Fire" }, "feunard.png", new Specifications(), new Weakness[] { new Weakness() } ),
            new Character(10, "Abra", 10, 20, new string[] { "Psy" }, "abra.png", new Specifications(), new Weakness[] { new Weakness() } ),
            new Character(11, "Racaillou", 11, 10, new string[] { "Earth", "Rock" }, "racaillou.png", new Specifications(), new Weakness[] { new Weakness() } ),
            new Character(12, "Grolem", 12, 5, new string[] { "Earth", "Rock" }, "grolem.png", new Specifications(), new Weakness[] { new Weakness() } )
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
