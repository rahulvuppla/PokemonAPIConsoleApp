using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class PokemonService : IPokemonService
{
    private readonly HttpClient _httpClient;

    public PokemonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Pokemon> GetPokemonAsync(string pokemonName)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}/");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(content);

                var pokemon = new Pokemon
                {
                    Name = data["name"].ToString()
                };

                foreach (var typeEntry in data["types"])
                {
                    var type = new TypeEntry
                    {
                        Type = new NamedApiResource
                        {
                            Name = typeEntry["type"]["name"].ToString(),
                            Url = typeEntry["type"]["url"].ToString()
                        }
                    };
                    pokemon.Types.Add(type);
                }

                return pokemon;
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Network error: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
        return null;
    }
}
