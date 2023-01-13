

internal class Program
{
  private static async Task Main(string[] args)
  {
    var tamagotchi = new TamagotchiController();
    tamagotchi.PresentationMenu();
    await tamagotchi.MainProgramAsync();
  }
}

