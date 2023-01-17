
using SevenDaysOfCode.TamagotchiCli.Data.DTO;
using SevenDaysOfCode.TamagotchiCli.Model;
using SevenDaysOfCode.TamagotchiCli.View.AscArt;

public class Menus
{
  public static void Presentation()
  {
    System.Console.Clear();

    TextAnimationUtils.Blink(MainLogo.logo, 3, 500, 250);

    System.Console.WriteLine(" ");
    System.Console.WriteLine(" ");
  }

  public static void Login()
  {
    System.Console.WriteLine("---------------- START ---------------");
    System.Console.WriteLine(" ");

    TextAnimationUtils.AnimatingTyping("Qual é o seu nome?");

    System.Console.WriteLine(" ");
  }

  public static void WelcomeMenu(string userName)
  {
    userName = userName.ToUpper();
    string textTitle = @$"
    Olá {userName}, você deseja:
    ";
    string textOptions = @"
    1 - Adotar um mascote virtual
    2 - Ver seus mascotes
    3 - Sair
    ";
    System.Console.WriteLine();
    System.Console.WriteLine("----------------- MENU ---------------");
    System.Console.WriteLine(" ");

    TextAnimationUtils.AnimatingTyping(textTitle, 25);

    System.Console.WriteLine(" ");

    TextAnimationUtils.AnimatingTyping(textOptions, 15);

    System.Console.WriteLine(" ");

  }

  public static void ChooseMascotList(string userName)
  {
    userName = userName.ToUpper();
    string textTitle = @$"{userName}, escolha uma espécie:";
    string textOptions = @"
    1 - Bulbasaur
    2 - Chamander
    3 - Squirtle
    4 - Pikachu
    5 - Zubat
    ";

    System.Console.WriteLine();
    System.Console.WriteLine("------------ ADOTAR MASCOTE ----------");
    System.Console.WriteLine(" ");

    TextAnimationUtils.AnimatingTyping(textTitle, 25);

    System.Console.WriteLine(" ");
    TextAnimationUtils.AnimatingTyping(textOptions, 15);
    System.Console.WriteLine(" ");

  }

  public static void MascotMenu(string userName, string pokemonName)
  {
    System.Console.WriteLine(PokemonArts(pokemonName));
    userName = userName.ToUpper();
    pokemonName = pokemonName.ToUpper();
    string textTitle = @$"
    Olá {userName}, você deseja:
    ";
    string textOptions = @$"
    1 - Ver a descrição de {pokemonName}
    2 - Adotar {pokemonName}
    3 - Voltar
    ";
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    TextAnimationUtils.AnimatingTyping(textTitle, 25);
    System.Console.WriteLine(" ");
    TextAnimationUtils.AnimatingTyping(textOptions, 15);
    System.Console.WriteLine(" ");
  }

  public static void MascotDescription(string pokemonDescription)
  {
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    TextAnimationUtils.AnimatingTyping(pokemonDescription, 20);
    System.Console.WriteLine(" ");
  }

  public static void MascotAdopted(string userName, string pokemonName)
  {
    userName = userName.ToUpper();
    pokemonName = pokemonName.ToUpper();
    string text = @$"
    {userName}, seu {pokemonName} foi adotado com sucesso!
    O ovo está chocando:
    ";
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    TextAnimationUtils.AnimatingTyping(text, 25);
    System.Console.WriteLine(" ");

    System.Console.WriteLine(Eggs.eggEmptyBackground);

    TextAnimationUtils.AnimatingTyping("Pressione uma tecla para continuar...", 15);
    System.Console.WriteLine(" ");
    Console.ReadKey();
  }

  public static void ShowMyMascotsList(List<ReadPokemonDTO> adoptedMascots)
  {

    if (!adoptedMascots.Any())
    {
      System.Console.WriteLine();
      System.Console.WriteLine("----------- Não há Mascotes ----------");
      System.Console.WriteLine(" ");
      TextAnimationUtils.AnimatingTyping("Você ainda não adotou nenhum mascote.", 25);

      System.Console.WriteLine(" ");
      return;
    }


    System.Console.WriteLine();
    System.Console.WriteLine("------------ Meus Mascotes ----------");
    System.Console.WriteLine(" ");
    TextAnimationUtils.AnimatingTyping("Selecione um mascote para ver mais sobre ele", 20);
    System.Console.WriteLine(" ");
    System.Console.WriteLine("0 - Voltar");
    foreach (var (mascot, index) in adoptedMascots.Select((Mascot, index) => (Mascot, index)))
    {
      System.Console.WriteLine($"{index + 1} - {mascot.name}");
    }
    System.Console.WriteLine(" ");

  }

  public static void ShowMyMascotMenu(string userName, string pokemonName, bool firstAppearance)
  {
    if (firstAppearance)
    {
      Eggs.CrakingEgg();
    }
    System.Console.WriteLine(PokemonArts(pokemonName));
    userName = userName.ToUpper();
    pokemonName = pokemonName.ToUpper();
    string textTitle = @$"
    {userName}, você deseja:
    ";
    string textOptions = @$"
    1 - Saber como {pokemonName} está
    2 - Alimentar o {pokemonName}
    3 - Brincar com {pokemonName}
    4 - Voltar
    ";
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    TextAnimationUtils.AnimatingTyping(textTitle);
    System.Console.WriteLine(" ");

    TextAnimationUtils.AnimatingTyping(textOptions, 15);
  }

  public static void ShowPokemonHealth(string pokemonName, string pokemonDescription, string pokemonHungry, string pokemonMood, int pokemonAge = 0)
  {
    pokemonName = pokemonName.ToUpper();
    string text =
    @$"
    {pokemonAge} anos em Mascote Virtual
    {pokemonName} {pokemonHungry}
    {pokemonName} {pokemonMood}
    ";

    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    TextAnimationUtils.AnimatingTyping(pokemonDescription, 15);
    TextAnimationUtils.AnimatingTyping(text, 15);
    System.Console.WriteLine(" ");

    TextAnimationUtils.AnimatingTyping("Pressione uma tecla para continuar...", 15);
    System.Console.WriteLine(" ");

    System.Console.ReadKey();
  }

  public static void HappyMascotFace(string message)
  {
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine(" ( = ^ w ^ =) ");
    System.Console.WriteLine(" ");
    System.Console.WriteLine(message);
    System.Console.WriteLine(" ");
    System.Console.WriteLine("Pressione uma tecla para continuar...");
    System.Console.ReadKey();
  }

  public static void SadMascotFace(string message)
  {
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine(" ( =  ˘︹˘  = ) ");
    System.Console.WriteLine(" ");
    System.Console.WriteLine(message);
    System.Console.WriteLine(" ");
    System.Console.WriteLine("Pressione uma tecla para continuar...");
    System.Console.ReadKey();
  }
  public static void ShowErrorMessage(string message)
  {
    System.Console.Clear();
    System.Console.WriteLine(message);
    TextAnimationUtils.AnimatingTyping("Pressione uma tecla para continuar...", 15);
    System.Console.WriteLine(" ");
    System.Console.ReadKey();
  }
  private static string PokemonArts(string pokemonName)
  {
    PokemonArts pokemonArts = new();
    string art = pokemonArts.pokemon[pokemonName];
    return art;
  }

}
