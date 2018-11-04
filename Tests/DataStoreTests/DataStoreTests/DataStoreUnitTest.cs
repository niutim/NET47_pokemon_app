using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonShared.Models;

namespace DataStoreTests
{
    [TestClass]
    public class DataStoreUnitTest
    {
        [TestMethod]
        public void GetCharactersTest()
        {
            List<Character> characterList = PokemonDataStore.Adapters.CharacterAdapter.GetCharacters();
            Assert.IsNotNull(characterList);
            Assert.IsTrue(characterList.Count > 0);
        }

        [TestMethod]
        public void GetCharactersContainsPikachuTest()
        {
            List<Character> characterList = PokemonDataStore.Adapters.CharacterAdapter.GetCharacters();
            Assert.IsNotNull(characterList);
            Assert.IsTrue(characterList.Any<Character>(chr => chr.Name.ToLower()=="pikachu"));
        }
    }
}
