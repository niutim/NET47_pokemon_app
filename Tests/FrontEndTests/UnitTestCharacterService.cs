using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonShared.Models;
using PokemonFrontEnd.Services;

namespace FrontEndTests
{
    [TestClass]
    public class UnitTestCharacterService
    {
        [TestMethod]
        public void GetCharacterTask()
        {
            Task<Character> character = CharacterService.GetCharacterByNameAsync("Salameche");
            Assert.IsNotNull(character);

        }
    }
}
