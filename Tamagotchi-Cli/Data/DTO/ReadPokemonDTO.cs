using SevenDaysOfCode.TamagotchiCli.Model.MascotDescription;

namespace SevenDaysOfCode.TamagotchiCli.Data.DTO;

public class ReadPokemonDTO
{
  public readonly string? name;
  public readonly int height;
  public readonly int weight;
  public readonly List<AbilitiesClass>? abilities;
  public readonly List<Types>? types;
  public readonly bool FirstAppearance;
  public readonly int Age;

  public ReadPokemonDTO(
    string? name = "",
    int height = 0,
    int weight = 0,
    List<AbilitiesClass>? abilities = null,
    List<Types>? types = null,
    bool firstAppearance = false,
    int age = 0)
  {
    this.name = name;
    this.height = height;
    this.weight = weight;
    this.abilities = abilities;
    this.types = types;
    FirstAppearance = firstAppearance;
    Age = age;
  }

  public override string ToString()
  {
    string skills = string.Empty;
    if (abilities != null)
    {
      foreach (var skill in abilities)
      {
        skills += skill.ability!.name + " ";
      }
    }
    string pokemonTypes = string.Empty;
    if (types != null)
    {
      foreach (var type in types)
      {
        pokemonTypes += type.type!.name + " ";
      }
    }

    string response = $"Nome: {name!.ToUpper()}\n" +
                      $"Altura: {height}\n" +
                      $"Peso: {weight}\n" +
                      "Habilidades: " +
                      skills.Trim().Replace(" ", ", ") + "\n" +
                      "Tipo: " +
                      pokemonTypes.Trim().Replace(" ", ", ")
                       ;
    return response;
  }

}