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

  public List<Pokemon> GetMascotsList()
  {
    return new List<Pokemon>(_mascotsDB.AdoptedMascotsList);
  }

  public void AdoptMascot(ReadPokemonDTO mascot)
  {
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

  public bool FeedPokemon(Pokemon pokemon)
  {
    if (pokemon.Hungry < 4) return false;

    pokemon.FeedPokemon();

    return true;
  }

  public bool PlayWithPokemon(Pokemon pokemon)
  {
    if (pokemon.Hungry > 8) return false;

    pokemon.PlayWithPokemon();

    return true;
  }

  public string GetPokemonHealth(Pokemon p)
  {

    var pokemon = GetPokemonFromList(p);

    if (pokemon.Hungry >= 6) return "está com muita fome";

    if (pokemon.Hungry > 3) return "está com fome";

    return "está alimentado";
  }

  public string GetPokemonMood(Pokemon p)
  {
    var pokemon = GetPokemonFromList(p);

    if (pokemon.Mood < 3) return "está triste!";

    if (pokemon.Mood < 6) return "está entediado";

    return "está feliz!";
  }

  private Pokemon? GetPokemonFromList(Pokemon pokemon)
  {
    return _mascotsDB.AdoptedMascotsList.Where(p => p.name == pokemon.name).Single();
  }

}