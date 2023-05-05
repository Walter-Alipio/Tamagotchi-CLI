namespace SevenDaysOfCode.TamagotchiCli.Model.MascotDescription;

public class AbilitiesClass
{
  public AbilityClass ability { get; set; } = new();

  public override string ToString()
  {
    return ability.name;
  }
}

public class AbilityClass
{
  public string name { get; set; } = string.Empty;
}