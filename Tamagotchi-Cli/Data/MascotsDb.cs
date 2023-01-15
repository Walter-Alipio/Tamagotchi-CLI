
using SevenDaysOfCode.TamagotchiCli.Model;

namespace SevenDaysOfCode.TamagotchiCli.Data;

public class MascotsDb
{
  public List<Pokemon> AdoptedMascotsList { get; }
  public MascotsDb()
  {
    AdoptedMascotsList = new List<Pokemon>();
  }
}