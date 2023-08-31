using Newtonsoft.Json.Linq;
using System.Net.Http;

public class TypeEffectivenessService : ITypeEffectivenessService
{
    private readonly HttpClient _httpClient;

    public TypeEffectivenessService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TypeEffectiveness> GetTypeEffectivenessAsync(string typeUrl)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(typeUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(content);

                var typeEffectiveness = new TypeEffectiveness();

                foreach (var doubleDamageTo in data["damage_relations"]["double_damage_to"])
                {
                    typeEffectiveness.DoubleDamageTo.Add(new NamedApiResource
                    {
                        Name = doubleDamageTo["name"].ToString()
                    });
                }

                foreach (var halfDamageTo in data["damage_relations"]["half_damage_to"])
                {
                    typeEffectiveness.HalfDamageTo.Add(new NamedApiResource
                    {
                        Name = halfDamageTo["name"].ToString()
                    });
                }

                foreach (var noDamageTo in data["damage_relations"]["no_damage_to"])
                {
                    typeEffectiveness.NoDamageTo.Add(new NamedApiResource
                    {
                        Name = noDamageTo["name"].ToString()
                    });
                }

                foreach (var doubleDamageFrom in data["damage_relations"]["double_damage_from"])
                {
                    typeEffectiveness.DoubleDamageFrom.Add(new NamedApiResource
                    {
                        Name = doubleDamageFrom["name"].ToString()
                    });
                }

                foreach (var halfDamageFrom in data["damage_relations"]["half_damage_from"])
                {
                    typeEffectiveness.HalfDamageFrom.Add(new NamedApiResource
                    {
                        Name = halfDamageFrom["name"].ToString()
                    });
                }

                foreach (var noDamageFrom in data["damage_relations"]["no_damage_from"])
                {
                    typeEffectiveness.NoDamageFrom.Add(new NamedApiResource
                    {
                        Name = noDamageFrom["name"].ToString()
                    });
                }

                return typeEffectiveness;
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




