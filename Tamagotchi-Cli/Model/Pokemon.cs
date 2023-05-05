using SevenDaysOfCode.TamagotchiCli.Model.MascotDescription;

namespace SevenDaysOfCode.TamagotchiCli.Model;

public class Pokemon
{
  public string? name { get; set; }
  public int height { get; set; }
  public int weight { get; set; }
  public List<AbilitiesClass> abilities { get; set; } = new();
  public List<Types> types { get; set; } = new();
  public DateTime AdoptedDate;
  public bool FirstAppearance { get; set; }

  public Pokemon()
  {
    AdoptedDate = new DateTime();
    FirstAppearance = true;
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
        pokemonTypes += type.type?.name + " ";
      }
    }

    string response = $"Nome: {name?.ToUpper()}\n" +
                      $"Altura: {height}\n" +
                      $"Peso: {weight}\n" +
                      "Habilidades: " +
                      skills.Trim().Replace(" ", ", ") + "\n" +
                      "Tipo: " +
                      pokemonTypes.Trim().Replace(" ", ", ")
                       ;
    return response;
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