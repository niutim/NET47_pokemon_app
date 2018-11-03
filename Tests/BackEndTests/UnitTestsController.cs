using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonShared.Models;
using PokemonBackEnd.Controllers;
using System.Linq;

namespace BackEndTests.UnitTestsController
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetAllCharactersTest()
        {
            var controller = new CharactersController();

            var result = controller.GetAllCharacters() as Character[];

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetPikachuTest()
        {
            var controller = new CharactersController();

            Character character = new Character() { Id = 1, Name = "Pikachu" };

            var result = controller.GetCharacterByName("Pikachu") as System.Web.Http.Results.OkNegotiatedContentResult<Character>;
            Assert.IsNotNull(result, "L'objet en retour du controller n'est pas celui attendu.");
            Character characterSent = result.Content as Character;

            Assert.AreEqual(characterSent.Id, character.Id);
            Assert.AreEqual(characterSent.Name, character.Name);
        }

        [TestMethod]
        public void GetSalamecheTest()
        {
            var controller = new CharactersController();

            Character character = new Character() { Id = 2, Name = "Salameche" };

            var result = controller.GetCharacterByName("Salameche") as System.Web.Http.Results.OkNegotiatedContentResult<Character>;
            Assert.IsNotNull(result, "L'objet en retour du controller n'est pas celui attendu.");

            Character characterSent = result.Content as Character;

            Assert.AreEqual(characterSent.Id, character.Id);
            Assert.AreEqual(characterSent.Name, character.Name);
        }

        [TestMethod]
        public void GetCharactersContainingStringTest()
        {
            var controller = new CharactersController();

            Character character = new Character() { Id = 1, Name = "Pikachu" };

            var result = controller.GetCharactersContainingString("P") as System.Web.Http.Results.OkNegotiatedContentResult<Character[]>;
            Assert.IsNotNull(result, "L'objet en retour du controller n'est pas celui attendu.");

            Character[] characterSent = result.Content as Character[];
            Assert.IsNotNull(characterSent);
            Assert.IsTrue(characterSent.Length>0);
            Assert.IsTrue(characterSent.ToList().All<Character>(chr => chr.Name.ToLower().Contains("p")));
        }

        [TestMethod]
        public void GetEmptyCharactersContainingStringTest()
        {
            var controller = new CharactersController();

            var result = controller.GetCharactersContainingString("1") as System.Web.Http.Results.OkNegotiatedContentResult<Character[]>;
            Assert.IsNotNull(result, "L'objet en retour du controller n'est pas celui attendu.");

            Character[] characterSent = result.Content as Character[];
            Assert.IsNotNull(characterSent);
            Assert.IsTrue(characterSent.Length == 0);

        }


        [TestMethod]
        public void GetTopTenCharactersCheckOrderTest()
        {
            var controller = new CharactersController();
            var result = controller.GetTopXXCharacters(10) as System.Web.Http.Results.OkNegotiatedContentResult<Character[]>;

            Assert.IsNotNull(result, "L'objet en retour du controller n'est pas celui attendu.");

            Character[] topTenCharactersSent = result.Content as Character[];

            Assert.AreEqual(topTenCharactersSent.Length, 10);

            var maxVotes = topTenCharactersSent.Max<Character>(chr => chr.Ranking.Votes);

            Assert.AreEqual(topTenCharactersSent[0].Ranking.Votes, maxVotes);

        }

        [TestMethod]
        public void GetTopCharactersSizeTest()
        {
            var controller = new CharactersController();
            var result = controller.GetTopXXCharacters(3) as System.Web.Http.Results.OkNegotiatedContentResult<Character[]>;

            Assert.IsNotNull(result, "L'objet en retour du controller n'est pas celui attendu.");

            Character[] topTenCharactersSent = result.Content as Character[];

            Assert.AreEqual(topTenCharactersSent.Length, 3);

        }

        [TestMethod]
		public void GetVoteForFirstFoundCharacterTest()
		{
			var controller = new CharactersController();

			var allCharactersResult = controller.GetAllCharacters() as Character[];
			Assert.IsNotNull(allCharactersResult);
			Assert.IsTrue(allCharactersResult.Length>1);

			long currentVotesCount = allCharactersResult[0].Ranking.Votes;

			var result = controller.GetVoteForCharacter(allCharactersResult[0].Id) as System.Web.Http.Results.OkNegotiatedContentResult<Character>;
			Assert.IsNotNull(result, "L'objet en retour du controller n'est pas celui attendu.");

			Character newVoteCharacterSent = result.Content as Character;

			Assert.IsNotNull(newVoteCharacterSent);
			Assert.AreEqual(newVoteCharacterSent.Ranking.Votes, currentVotesCount+1);

		}

	}
}
