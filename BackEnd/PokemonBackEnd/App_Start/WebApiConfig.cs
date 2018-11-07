using System.Net.Http.Headers;
using System.Web.Http;

namespace PokemonBackEnd
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            config.Routes.MapHttpRoute(
                name: "GetCharacterById",
                routeTemplate: "api/{controller}/id/{id}"
            );

            config.Routes.MapHttpRoute(
                name: "GetCharacterByName",
                routeTemplate: "api/{controller}/name/{name}"
            );

            config.Routes.MapHttpRoute(
                name: "GetCharactersContainingString",
                routeTemplate: "api/{controller}/contains/{search}"
            );

            config.Routes.MapHttpRoute(
                name: "GetTopXXCharacters",
                routeTemplate: "api/{controller}/top/{count}"
			);

            config.Routes.MapHttpRoute(
                name: "GetAverageSpecifications",
                routeTemplate: "api/{controller}/average/{classesName}"
            );

            config.Routes.MapHttpRoute(
				name: "GetVoteForCharacter",
				routeTemplate: "api/{controller}/vote/{charId}"
			);
        }
    }
}
