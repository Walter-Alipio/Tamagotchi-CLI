using System.Text.Json;
using SevenDaysOfCode.TamagotchiCli.Data;
using SevenDaysOfCode.TamagotchiCli.Data.DTO;
using SevenDaysOfCode.TamagotchiCli.Model;
using SevenDaysOfCode.TamagotchiCli.Utils;

namespace SevenDaysOfCode.TamagotchiCli.Service;

public class TamagotchiService
{
  private readonly MascotsDb _adoptedMascots;

  public TamagotchiService(MascotsDb adoptedMascots)
  {
    _adoptedMascots = adoptedMascots;
  }

  public bool ValidateUserName(string? userName)
  {
    if (string.IsNullOrEmpty(userName))
    {
      throw new ArgumentNullException("Por favor, diga seu nome.");
    }

    if (userName.Length < 3 || userName.Length > 15)
    {
      throw new ArgumentOutOfRangeException("O nome deve ter no mínimo 3 e no máximo 15 caracteres");
    }

    return true;
  }

  public async Task<ReadPokemonDTO> GetPokemonDescriptionAsync(string mascotName)
  {
    var pokemonDescription = await GetPokemonFromAPI.GetPokemonDescription(mascotName);
    var mascot = JsonSerializer.Deserialize<CreatePokemonDTO>(pokemonDescription);

    if (mascot is null)
    {
      throw new NullReferenceException();
    }

    if (mascot.abilities is null || mascot.types is null)
    {
      throw new ArgumentNullException();
    }

    var pokemon = new ReadPokemonDTO(
      mascot.name,
      mascot.height,
      mascot.weight,
      new List<Model.MascotDescription.AbilitiesClass>(mascot.abilities),
      new List<Model.MascotDescription.Types>(mascot.types)
    );

    return pokemon;
  }

  public string SelectPokemonName(string response)
  {

    if (InvalidInputOptions(response))
    {
      throw new ArgumentNullException(" Não entendi sua resposta, pode repetir? ");
    }
    int res = Convert.ToInt32(response);

    if (res <= 0 || res >= 6)
    {
      throw new ArgumentOutOfRangeException(" Opção não encontrada.");
    }
    IDictionary<int, string> pokemonNames = new SortedDictionary<int, string>()
          {
            { 1 , "bulbasaur" },
            { 2 , "charmander" },
            { 3 , "squirtle" },
            { 4 , "pikachu" },
            { 5 , "zubat" }
          };

    return pokemonNames[res];
  }

  public bool IsMascotAlreadAdopted(ReadPokemonDTO pokemon)
  {
    return _adoptedMascots.AdoptedMascotsList.Exists(p => p.name == pokemon.name);
  }

  public bool InvalidInputOptions(string? response)
  {
    if (String.IsNullOrEmpty(response))
    {
      System.Console.WriteLine("Não encontrei essa opção");
      return true;
    }

    return false;
  }


}