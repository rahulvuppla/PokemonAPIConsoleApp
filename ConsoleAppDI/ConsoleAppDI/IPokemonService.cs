using System.Threading.Tasks;

public interface IPokemonService
{
    Task<Pokemon> GetPokemonAsync(string pokemonName);
}
