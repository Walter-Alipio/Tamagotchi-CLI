using SevenDaysOfCode.TamagotchiCli.Model.MascotDescription;

namespace SevenDaysOfCode.TamagotchiCli.Data.DTO;

public class ReadPokemonDTO
{
  public readonly string? name;
  public readonly int height;
  public readonly int weight;
  public readonly List<AbilitiesClass>? abilities;
  public readonly List<Types>? types;
  public ReadPokemonDTO(string? name, int height, int weight, List<AbilitiesClass>? abilities, List<Types>? types)
  {
    this.name = name;
    this.height = height;
    this.weight = weight;
    this.abilities = abilities;
    this.types = types;
  }

}