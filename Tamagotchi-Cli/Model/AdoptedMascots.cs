
namespace SevenDaysOfCode.TamagotchiCli.Model;

public class AdoptedMascots
{
  public List<Mascot> AdoptedMascotsList { get; }
  public AdoptedMascots()
  {
    AdoptedMascotsList = new List<Mascot>();
  }
}