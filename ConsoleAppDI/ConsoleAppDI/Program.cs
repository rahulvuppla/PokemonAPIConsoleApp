// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.Extensions.DependencyInjection;
class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = DependencyInjection.SetupServices();

        var pokemonService = serviceProvider.GetRequiredService<IPokemonService>();
        var typeEffectivenessService = serviceProvider.GetRequiredService<ITypeEffectivenessService>();

        await RunProgram(pokemonService, typeEffectivenessService);
    }

    static async Task RunProgram(IPokemonService pokemonService, ITypeEffectivenessService typeEffectivenessService)
    {
        Console.Write("Enter a Pokémon name: ");
        string pokemonName = Console.ReadLine();

        try
        {
            Pokemon pokemon = await pokemonService.GetPokemonAsync(pokemonName.ToLower());
            if (pokemon != null)
            {

                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine($"Type effectiveness for {pokemon.Name}:");

                foreach (var type in pokemon.Types)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    TypeEffectiveness typeEffectiveness = await typeEffectivenessService.GetTypeEffectivenessAsync(type.Type.Url);


                    Console.WriteLine($"Type: \x1B[4m{type.Type.Name.ToUpper()}\x1B[24m");

                    Console.WriteLine("Double Strong against:");
                    if (typeEffectiveness.DoubleDamageTo.Count != 0)
                    {
                        foreach (var strongType in typeEffectiveness.DoubleDamageTo)
                        {
                            Console.WriteLine($"- {strongType.Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("This Type Doesnot Do Double Damage  ");
                        Console.WriteLine("Normal Damage Done : ");

                        if (typeEffectiveness.HalfDamageTo.Count != 0)
                        {
                            foreach (var resistantType in typeEffectiveness.HalfDamageTo)
                            {
                                Console.WriteLine($"- {resistantType.Name}");
                            }
                        }
                        else { Console.WriteLine("This Type Doesnot Do Normal Damage Also"); }

                    }
                    //Console.WriteLine("Strong to:");
                    //if (typeEffectiveness.HalfDamageTo.Count != 0)
                    //{
                    //    foreach (var resistantType in typeEffectiveness.HalfDamageTo)
                    //    {
                    //        Console.WriteLine($"- {resistantType.Name}");
                    //    }
                    //}
                    //else { Console.WriteLine("- NONE "); }
                    Console.WriteLine("Doesnot Cause Damage To:");

                    if (typeEffectiveness.NoDamageTo.Count != 0)
                    {
                        foreach (var noEffectType in typeEffectiveness.NoDamageTo)
                        {
                            Console.WriteLine($"- {noEffectType.Name}");
                        }
                    }
                    else { Console.WriteLine("- Causes Damage To All Types "); }
                    Console.WriteLine("");

                    Console.WriteLine("Double Weak Against:");
                    if (typeEffectiveness.DoubleDamageFrom.Count != 0)
                    {
                        foreach (var weakTypeDouble in typeEffectiveness.DoubleDamageFrom)
                        {
                            Console.WriteLine($" - {weakTypeDouble.Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("This Type Is Not Double Weak  ");
                        Console.WriteLine("Normal Weak Against : ");


                        if (typeEffectiveness.HalfDamageFrom.Count != 0)
                        {
                            foreach (var weakTypeSingle in typeEffectiveness.HalfDamageFrom)
                            {
                                Console.WriteLine($"- {weakTypeSingle.Name}");
                            }
                        }
                        else { Console.WriteLine("- NONE "); }


                    }
                    //Console.WriteLine("weak  Against :");
                    //if (typeEffectiveness.HalfDamageFrom.Count != 0)
                    //{
                    //    foreach (var weakTypeSingle in typeEffectiveness.HalfDamageFrom)
                    //    {
                    //        Console.WriteLine($"- {weakTypeSingle.Name}");
                    //    }
                    //}
                    //else { Console.WriteLine("- NONE "); }
                    Console.WriteLine("Doesnot cause Damage From:");
                    if (typeEffectiveness.NoDamageFrom.Count != 0)
                    {
                        foreach (var noEffectType1 in typeEffectiveness.NoDamageFrom)
                        {
                            Console.WriteLine($"- {noEffectType1.Name}");
                        }
                    }
                    else { Console.WriteLine("- Causes Damage From All Types "); }
                    Console.WriteLine();
                }


                // ... rest of the main logic ...
            }
            else
            {
                Console.WriteLine("Pokémon not found.");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Network error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Invalid operation: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static Task<TypeEffectiveness> GetTypeEffectivenessAsync(string url)
    {
        throw new NotImplementedException();
    }
}


