using SevenDaysOfCode.TamagotchiCli.Data;
using SevenDaysOfCode.TamagotchiCli.Data.DTO;
using SevenDaysOfCode.TamagotchiCli.Model;

namespace SevenDaysOfCode.TamagotchiCli.Service;

public class AdoptedPokemonService
{
  private readonly MascotsDb _mascotsDB;

  public AdoptedPokemonService(MascotsDb adoptedMascots)
  {
    _mascotsDB = adoptedMascots;
  }

  public List<ReadPokemonDTO> GetMascotsList()
  {
    List<ReadPokemonDTO> readList = new List<ReadPokemonDTO>();
    foreach (var pokemon in _mascotsDB.AdoptedMascotsList)
    {
      readList.Add(
              new ReadPokemonDTO(
              pokemon.name,
              pokemon.height,
              pokemon.weight,
              new List<Model.MascotDescription.AbilitiesClass>(pokemon.abilities),
              new List<Model.MascotDescription.Types>(pokemon.types),
              pokemon.FirstAppearance
      ));
    }

    return readList;
  }

  public void AdoptMascot(ReadPokemonDTO mascot)
  {
    if (mascot.abilities is null || mascot.types is null)
    {
      throw new ArgumentNullException();
    }

    //Mapper
    Pokemon pokemon = new Pokemon()
    {
      name = mascot.name,
      height = mascot.height,
      weight = mascot.weight,
      abilities = new List<Model.MascotDescription.AbilitiesClass>(mascot.abilities),
      types = new List<Model.MascotDescription.Types>(mascot.types)
    };

    pokemon.AdoptedDate = DateTime.Now;

    _mascotsDB.AdoptedMascotsList.Add(pokemon);
  }

  public bool FeedPokemon(ReadPokemonDTO p)
  {
    var pokemon = GetPokemonFromList(p);
    if (pokemon is null)
    {
      throw new NullReferenceException();
    }
    if (pokemon.Hungry < 4) return false;

    pokemon.FeedPokemon();

    return true;
  }

  public bool PlayWithPokemon(ReadPokemonDTO p)
  {
    var pokemon = GetPokemonFromList(p);
    if (pokemon is null)
    {
      throw new NullReferenceException();
    }
    if (pokemon.Hungry > 8) return false;

    pokemon.PlayWithPokemon();

    return true;
  }

  public string GetPokemonHealth(ReadPokemonDTO p)
  {

    var pokemon = GetPokemonFromList(p);
    if (pokemon is null)
    {
      throw new NullReferenceException();
    }

    if (pokemon.Hungry >= 6) return "está com muita fome";

    if (pokemon.Hungry > 3) return "está com fome";

    return "está alimentado";
  }

  public string GetPokemonMood(ReadPokemonDTO p)
  {
    var pokemon = GetPokemonFromList(p);
    if (pokemon is null)
    {
      throw new NullReferenceException();
    }

    if (pokemon.Mood < 3) return "está triste!";

    if (pokemon.Mood < 6) return "está entediado";

    return "está feliz!";
  }

  public bool IsAFirstAppearance(ReadPokemonDTO p)
  {
    var pokemon = GetPokemonFromList(p);
    if (pokemon is null)
    {
      throw new NullReferenceException();
    }

    if (pokemon.FirstAppearance)
    {
      pokemon.FirstAppearance = false;
      return true;
    }
    return false;
  }
  private Pokemon? GetPokemonFromList(ReadPokemonDTO pokemon)
  {
    return _mascotsDB.AdoptedMascotsList.Where(p => p.name == pokemon.name).Single();
  }

}