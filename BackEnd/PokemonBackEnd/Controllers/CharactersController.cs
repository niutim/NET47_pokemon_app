using PokemonShared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PokemonBackEnd.Controllers
{
    public class CharactersController : ApiController
    {

		private Character[] characters =
		{
			new Character(1, "Pikachu", new Ranking() { Id=1, CharacterId=1, Votes=100 }, 
                                        new CharacterClass[] { new CharacterClass() { ClassId=1, ClassName="Electricity" } },
                                        "pikachu.png", new Specifications[] { new Specifications() { } }),
            new Character(2, "Salameche", new Ranking() { Id=2, CharacterId=2, Votes=99 }, 
                                          new CharacterClass[] { new CharacterClass() { ClassId=2, ClassName="Fire" } }, 
                                          "salameche.png",
                                          new Specifications[] { new Specifications() { } }),
			new Character(3, "BulleBizarre", new Ranking() { Id=5, CharacterId=5, Votes=80 }, 
                                            new CharacterClass[] { new CharacterClass() { ClassId=3, ClassName="Earth" } }, 
                                            "bulbasaur.jpg",
                                            new Specifications[] { new Specifications() { } }),
            new Character(4, "Venusaur", new Ranking() { Id=6, CharacterId=6, Votes=33 }, 
                                         new CharacterClass[] { new CharacterClass() { ClassId=4, ClassName="Water" } }, 
                                         "venusaur.png",
                                         new Specifications[] { new Specifications() { } }),

            

            new Character(5, "Dracaufeu", new Ranking() { Id=3, CharacterId=3, Votes=90 }, new CharacterClass[] { new CharacterClass() { ClassId=2, ClassName="Fire" }, new CharacterClass() { ClassId=5, ClassName="Fly" } }, "dracaufeu.png", new Specifications[] { new Specifications() { } }),
            new Character(6, "Carapuce", new Ranking() { Id=4, CharacterId=4, Votes=89 }, new CharacterClass[] { new CharacterClass() { ClassId=4, ClassName="Water" } }, "carapuce.png", new Specifications[] { new Specifications() { } }),
            new Character(7, "Aspicot", new Ranking() { Id=7, CharacterId=7, Votes=30 }, new CharacterClass[] { new CharacterClass() { ClassId=6, ClassName="Insect" }, new CharacterClass() { ClassId=7, ClassName="Poison" } }, "aspicot.png", new Specifications[] { new Specifications() { } }),
            new Character(8, "Sabelette", new Ranking() { Id=8, CharacterId=8, Votes=28 }, new CharacterClass[] { new CharacterClass() { ClassId=3, ClassName="Earth" } }, "", new Specifications[] { new Specifications() { } }),
            new Character(9, "Feunard", new Ranking() { Id=9, CharacterId=9, Votes=25 }, new CharacterClass[] { new CharacterClass() { ClassId=2, ClassName="Fire" } }, "", new Specifications[] { new Specifications() { } }),
            new Character(10, "Abra", new Ranking() { Id=10, CharacterId=10, Votes=20 }, new CharacterClass[] { new CharacterClass() { ClassId=8, ClassName="Psy" } }, "", new Specifications[] { new Specifications() { } }),
            new Character(11, "Racaillou", new Ranking() { Id=11, CharacterId=11, Votes=10 }, new CharacterClass[] { new CharacterClass() { ClassId=3, ClassName="Earth" }, new CharacterClass() { ClassId=9, ClassName="Rock" } }, "", new Specifications[] { new Specifications() { } }),
            new Character(12, "Grolem", new Ranking() { Id=12, CharacterId=12, Votes=5 }, new CharacterClass[] { new CharacterClass() { ClassId=3, ClassName="Earth" }, new CharacterClass() { ClassId=9, ClassName="Rock" } }, "", new Specifications[] { new Specifications() { } })
        };

        public IEnumerable<Character> GetAllCharacters()
        {
            return characters;
        }

        [Route("api/characters/id/{id}")]
        public IHttpActionResult GetCharacterById(int id)
        {
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
            var firstTenCharacters = characters.ToList<Character>().OrderByDescending(c => c.Ranking.Votes).ToArray<Character>().Take<Character>(count).ToArray<Character>();
            if (firstTenCharacters == null)
            {
                return NotFound();
            }
            return Ok(firstTenCharacters);
        }

        [Route("api/characters/vote/{charId}")]
        public IHttpActionResult GetVoteForCharacter(int charId)
		{
			var character = characters.First<Character>(c => c.Id == charId);
			if (character == null)
			{
				return NotFound();
			}
			else
				character.Ranking.Votes++;
			return Ok(character);
		}

		
	}
}
