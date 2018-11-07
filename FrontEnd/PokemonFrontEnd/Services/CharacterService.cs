using PokemonShared.Models;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PokemonFrontEnd.Services
{
    public static class CharacterService
    {

        private static readonly string serviceURL;
        private static readonly HttpClient httpClient;

        static CharacterService()
        {
            httpClient = new HttpClient();
            serviceURL = ConfigurationManager.AppSettings["server"] + "api/characters/";
        }

        public static async Task<Character> GetCharacterByIdAsync(long id)
        {
            Character character = null;
            HttpResponseMessage response = await httpClient.GetAsync(serviceURL + "id/" + id);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                character = new JavaScriptSerializer().Deserialize<Character>(resultString);
            }
            return character;
        }

        public static async Task<Character> GetCharacterByNameAsync(string name)
        {
            Character character = null;
            HttpResponseMessage response = await httpClient.GetAsync(serviceURL + "name/" + name);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                character = new JavaScriptSerializer().Deserialize<Character>(resultString);
            }
            return character;
        }

        public static async Task<Character[]> GetCharactersContainingStringAsync(string searchedText)
        {
            Character[] characters = null;
            HttpResponseMessage response = await httpClient.GetAsync(serviceURL + "contains/" + searchedText);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                characters = new JavaScriptSerializer().Deserialize<Character[]>(resultString);
            }
            return characters;
        }

        public static async Task<Character[]> GetTopXXCharacterAsync(int count)
        {

            Character[] topCharacters = null;
            HttpResponseMessage response = await httpClient.GetAsync(serviceURL + "top/" + count);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                topCharacters = new JavaScriptSerializer().Deserialize<Character[]>(resultString);
            }
            return topCharacters;
        }

        public static async Task<Specifications> GetAverageSpecificationsAsync(string[] classesName)
        {

            Specifications specifications = null;
            string str = new JavaScriptSerializer().Serialize(classesName);

            HttpResponseMessage response = await httpClient.GetAsync(serviceURL + "average/"+ str);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                specifications = new JavaScriptSerializer().Deserialize<Specifications>(resultString);
            }
            return specifications;
        }

        public static async Task<Character> VoteForCharacterAsync(long id)
		{

			Character character = null;
			HttpResponseMessage response = await httpClient.GetAsync(serviceURL + "vote/" + id);
			if (response.IsSuccessStatusCode)
			{
				string resultString = await response.Content.ReadAsStringAsync();
				character = new JavaScriptSerializer().Deserialize<Character>(resultString);
			}
			return character;
		}

	}
}
