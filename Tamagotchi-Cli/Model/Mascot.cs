

using SevenDaysOfCode.TamagotchiCli.Model.MascotDescription;

namespace SevenDaysOfCode.TamagotchiCli.Model;

public class Mascot
{
  public string? name { get; set; }
  public int height { get; set; }
  public int weight { get; set; }
  public List<AbilitiesClass>? abilities { get; set; }
  public List<Types>? types { get; set; }
  public DateTime AdoptedDate;

  public Mascot()
  {
    AdoptedDate = new DateTime();
  }

  public int Age { get; set; }
  public int Hungry { get; set; }
  public int Mood { get; set; }
  public int Sleep { get; set; }

  public override string ToString()
  {
    string skills = string.Empty;
    if (abilities != null)
    {
      foreach (var skill in abilities)
      {
        skills += skill.ability.name + " ";
      }
    }
    string pokemonTypes = string.Empty;
    if (types != null)
    {
      foreach (var type in types)
      {
        pokemonTypes += type.type.name + " ";
      }
    }

    string response = $"Nome: {name.ToUpper()}\n" +
                      $"Altura: {height}\n" +
                      $"Peso: {weight}\n" +
                      "Habilidades: " +
                      skills.Trim().Replace(" ", ", ") + "\n" +
                      "Tipo: " +
                      pokemonTypes.Trim().Replace(" ", ", ")
                       ;
    return response;
  }

  public string PokemonHungry()
  {
    if (Hungry >= 6) return "está com muita fome";

    if (Hungry > 3) return "está com fome";

    return "está alimentado";
  }

  public string PokemonMood()
  {
    if (Mood < 3) return "está triste!";

    if (Mood < 6) return "está entediado";

    return "está feliz!";
  }

  public void FeedPokemon()
  {
    Hungry--;
    Mood++;
  }

  public void PlayWithPokemon()
  {
    Mood++;
    Hungry += 2;
  }

}