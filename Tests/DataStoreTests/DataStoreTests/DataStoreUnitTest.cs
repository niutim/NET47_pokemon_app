using System;
using System.Collections.Generic;
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
        }
    }
}
