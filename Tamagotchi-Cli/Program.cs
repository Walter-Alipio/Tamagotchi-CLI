

using SevenDaysOfCode.TamagotchiCli.Model;
using SevenDaysOfCode.TamagotchiCli.Service;

internal class Program
{
  private static async Task Main(string[] args)
  {
    var adopet = new AdoptedMascots();
    var service = new TamagotchiService(adopet);

    var tamagotchi = new TamagotchiController(service);

    tamagotchi.LoginMenu();

    await tamagotchi.MainMenuAsync();
  }
}

