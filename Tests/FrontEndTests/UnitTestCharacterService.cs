using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonShared.Models;
using PokemonFrontEnd.Services;

namespace FrontEndTests
{
    /// <summary>
    /// Tests unitaires sur FrontEnd
    /// </summary>
    /// <remarks> Pas de mock utilisé, a lancer lorsque le serveur back est demarre</remarks>
    [TestClass]
    public class UnitTestCharacterService
    {
        [TestMethod]
        public void GetCharacterSalamecheTaskAsyncTest()
        {
            Task<Character> task = CharacterService.GetCharacterByNameAsync("Salameche");
            task.Wait();
            if (task.IsCompleted)
            {
                Character character = task.Result as Character;
                Assert.IsNotNull(character);
                Assert.IsTrue(character.Name.ToLower().Equals("salameche"));
            }
        }

        [TestMethod]
        public void GetCharacterPikachuByIdTaskAsyncTest()
        {
            Task<Character> task = CharacterService.GetCharacterByIdAsync(1);
            task.Wait();
            if (task.IsCompleted)
            {
                Character character = task.Result as Character;
                Assert.IsNotNull(character);
                Assert.IsTrue(character.Name.ToLower().Equals("pikachu"));
            }
        }

        [TestMethod]
        public void GetTop3CharactersAsyncTest()
        {
            Task<Character[]> task = CharacterService.GetTopXXCharacterAsync(3);
            task.Wait();
            if (task.IsCompleted)
            {
                Character[] characters = task.Result as Character[];
                Assert.IsNotNull(characters);
                Assert.IsTrue(characters.Length==3);
            }
        }

        [TestMethod]
        public void GetTopCharactersOrderAsyncTest()
        {
            Task<Character[]> task = CharacterService.GetTopXXCharacterAsync(10);
            task.Wait();
            if (task.IsCompleted)
            {
                Character[] characters = task.Result as Character[];
                Assert.IsNotNull(characters);
                Assert.IsTrue(characters[0].Rank == 1);
            }
        }

        [TestMethod]
        public void GetCharactersContainingPLetterAsyncTest()
        {
            Task<Character[]> task = CharacterService.GetCharactersContainingStringAsync("p");
            task.Wait();
            if (task.IsCompleted)
            {
                Character[] characters = task.Result as Character[];
                Assert.IsNotNull(characters);
                Assert.IsTrue(characters.Length>0);
            }
        }

        [TestMethod]
        public void GetAverageSpecificationsOneClassResultAsyncTest()
        {
            string[] classesName = { "Earth" };
            Task<Specifications> task = CharacterService.GetAverageSpecificationsAsync(classesName);
            task.Wait();
            if (task.IsCompleted)
            {
                Specifications specifications = task.Result as Specifications;
                Assert.IsNotNull(specifications);
                Assert.IsTrue(specifications.LifePoints>0);
            }
        }

        [TestMethod]
        public void GetAverageSpecificationsTwoClassesResultAsyncTest()
        {
            string[] classesName = { "Earth", "Rock" };
            Task<Specifications> task = CharacterService.GetAverageSpecificationsAsync(classesName);
            task.Wait();
            if (task.IsCompleted)
            {
                Specifications specifications = task.Result as Specifications;
                Assert.IsNotNull(specifications);
                Assert.IsTrue(specifications.LifePoints > 0);
            }
        }

        [TestMethod]
        public void GetVoteCharacterResultAsyncTest()
        {
            long votes = 0;
            Task<Character> task = CharacterService.GetCharacterByIdAsync(1);
            task.Wait();
            if (task.IsCompleted)
            {
                Character character = task.Result as Character;
                Assert.IsNotNull(character);
                votes = character.Votes;
            }

            task = CharacterService.VoteForCharacterAsync(1);
            task.Wait();
            if (task.IsCompleted)
            {
                Character character = task.Result as Character;
                Assert.IsNotNull(character);
                Assert.IsTrue(character.Votes==votes+1);
            }
        }

    }
}
