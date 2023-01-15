
using SevenDaysOfCode.TamagotchiCli.Data;
using SevenDaysOfCode.TamagotchiCli.Service;

internal class Program
{
  private static async Task Main(string[] args)
  {
    var adopetDB = new MascotsDb();
    var adopetPokemonService = new AdoptedPokemonService(adopetDB);
    var tamagotchiService = new TamagotchiService(adopetDB);

    var tamagotchi = new TamagotchiController(tamagotchiService, adopetPokemonService);

    tamagotchi.LoginMenu();

    await tamagotchi.MainMenuAsync();
  }
}

