# PokemonAPIConsoleApp

# Pokémon Type Effectiveness Console App

This console application allows you to determine a given Pokémon's effectiveness against other Pokémon types based on their type.

## How Pokémon Types Work

Each Pokémon has one or more types (e.g., ground, electric, water), and their attacks deal different levels of damage to other Pokémon based on their types. The application helps you understand how much damage a Pokémon's attacks would do against other types.

## Getting Started

### Prerequisites

- .NET 6 SDK
- Visual Studio or any code editor of your choice

### Installation and Usage

1. Clone the repository:

   ```sh
   https://github.com/rahulvuppla/PokemonAPIConsoleApp.git
Open the solution file ConsoleAppDI.sln in Visual Studio or your preferred code editor.

Build the solution to restore NuGet packages and compile the project.

Run the console application. Enter the name of a Pokémon, and the application will display its type effectiveness against other types.

### Project Structure

ConsoleAppDI: Main project folder.
Program.cs: Entry point of the console application.
DependencyInjection.cs: Configures dependency injection using Microsoft.Extensions.DependencyInjection.
Models: Contains model classes for Pokémon, type effectiveness, and API resources.
Services: Contains service interfaces and implementations for fetching Pokémon and type effectiveness data.
### Example Output:
![image](https://github.com/rahulvuppla/PokemonAPIConsoleApp/assets/79802988/38ace129-5cf6-40e8-ab41-58ae513df90f)

In the Above output i have displayed only "Extra Strong Against,Doesnot Cause Damage to, Extra Weak against and doesnot cause damage from" Types because i  thought they 4 together make an easily readable and understandable output .I tried to keep it simple.

