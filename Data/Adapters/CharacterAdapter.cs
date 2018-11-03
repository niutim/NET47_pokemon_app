using PokemonShared.Models;
using System.Collections.Generic;

namespace PokemonDataStore.Adapters
{
    public class CharacterAdapter
    {
        public List<Character> GetCharacter()
        {
            List<Character> charactersList = new List<Character>();

            using (Entity.PoketMonstersDB pmDB = new Entity.PoketMonstersDB())
            {
            }

            return charactersList;
        }
    }
}
