using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceProvider SetupServices()
    {
        return new ServiceCollection()
            .AddHttpClient()
            .AddScoped<IPokemonService, PokemonService>()
            .AddScoped<ITypeEffectivenessService, TypeEffectivenessService>()
            .BuildServiceProvider();
    }
}
