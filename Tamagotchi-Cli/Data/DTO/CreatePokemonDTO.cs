using SevenDaysOfCode.TamagotchiCli.Model.MascotDescription;

namespace SevenDaysOfCode.TamagotchiCli.Data.DTO;

public class CreatePokemonDTO
{
  public string? name { get; set; }
  public int height { get; set; }
  public int weight { get; set; }
  public List<AbilitiesClass>? abilities { get; set; }
  public List<Types>? types { get; set; }
  public DateTime AdoptedDate;

  public CreatePokemonDTO()
  {
    AdoptedDate = new DateTime();
  }

  public int Age { get; set; }
  public int Hungry { get; set; }
  public int Mood { get; set; }
  public int Sleep { get; set; }
}