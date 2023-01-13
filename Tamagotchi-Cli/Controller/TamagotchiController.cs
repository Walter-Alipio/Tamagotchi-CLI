
using System.Text.Json;
using SevenDaysOfCode.TamagotchiCli;
using SevenDaysOfCode.TamagotchiCli.Model;

public class TamagotchiController
{
  private string? _userName = String.Empty;
  private string? _mascotName = String.Empty;

  public void PresentationMenu()
  {
    bool opt = false;
    while (opt == false)
    {
      try
      {
        Menus.Presentation();
        Menus.Login();
        _userName = Console.ReadLine();

        opt = ValidateUserName(_userName);
      }
      catch (ArgumentNullException e)
      {
        System.Console.Clear();
        System.Console.WriteLine(" ");
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("Pressione uma tecla para continuar...");
        System.Console.ReadKey();

      }
      catch (ArgumentOutOfRangeException e)
      {
        System.Console.Clear();
        System.Console.WriteLine(" ");
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("Pressione uma tecla para continuar...");
        System.Console.ReadKey();

      }

    }
  }

  public async Task MainProgramAsync()
  {

    bool menuOption = false;
    while (menuOption == false)
    {
      Menus.WelcomeMenu(_userName!);
      var response = Console.ReadLine();

      try
      {
        if (InvalidInputOptions(response)) continue;

        int option = Convert.ToInt32(response);

        switch (option)
        {
          case 1:
            System.Console.Clear();
            _mascotName = ChooseYourPokemon(_userName);

            if (!String.IsNullOrEmpty(_mascotName))
            {
              await ShowMascotMenuAsync(_userName, _mascotName);
            }
            break;
          case 2:
            System.Console.Clear();
            System.Console.WriteLine("Não implementado...");
            System.Console.WriteLine("Pressione uma tecla para continuar...");
            System.Console.ReadKey();
            break;
          case 3:
            menuOption = true;
            break;
          default:
            System.Console.Clear();
            System.Console.WriteLine("Opção não encontrada");
            System.Console.WriteLine("Pressione uma tecla para continuar...");
            System.Console.ReadKey();
            break;
        }
      }
      catch (System.Exception e)
      {
        System.Console.Clear();
        System.Console.WriteLine("Opção não encontrada");
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("Pressione uma tecla para continuar...");
        System.Console.ReadKey();

        menuOption = false;
      }
    }

  }

  private static string ChooseYourPokemon(string userName)
  {
    string mascotName = String.Empty;

    var choice = false;
    while (choice == false)
    {
      try
      {
        Menus.ChooseMascotList(userName);
        var response = Console.ReadLine();
        if (InvalidInputOptions(response))
        {
          continue;
        }
        int res = Convert.ToInt32(response);

        if (res <= 0 || res >= 6)
        {
          System.Console.WriteLine(" Opção não encontrada.");
          continue;
        }
        IDictionary<int, string> pokemonNames = new SortedDictionary<int, string>()
          {
            { 1 , "bulbasaur" },
            { 2 , "charmander" },
            { 3 , "squirtle" },
            { 4 , "pikachu" },
            { 5 , "zubat" }
          };
        mascotName = pokemonNames[res];
        choice = true;
      }
      catch (FormatException e)
      {
        System.Console.Clear();
        System.Console.WriteLine("Utilize apenas números");
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("Pressione uma tecla para continuar...");
        System.Console.Read();
        break;
      }
    }
    return mascotName;
  }
  private static async Task ShowMascotMenuAsync(string userName, string mascotName)
  {
    var choice = false;
    while (choice == false)
    {
      System.Console.Clear();
      Menus.MascotMenu(userName, mascotName);
      var responseMascotMenu = Console.ReadLine();
      if (String.IsNullOrEmpty(responseMascotMenu))
      {
        System.Console.WriteLine(" Não entendi sua resposta, pode repetir? ");
        System.Console.WriteLine("Pressione uma tecla para continuar...");
        Console.ReadKey();
        continue;
      }
      try
      {
        int mascotOption = Convert.ToInt32(responseMascotMenu);

        if (mascotOption <= 0 || mascotOption >= 6)
        {
          System.Console.WriteLine(" Opção inválida.");
          System.Console.WriteLine("Pressione uma tecla para continuar...");
          Console.ReadKey();
          continue;
        }

        switch (mascotOption)
        {
          case 1:

            string pokemonDescription = await GetPokemonDescriptionAsync(mascotName);
            Menus.MascotDescription(pokemonDescription);
            System.Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
            break;
          case 2:
            Menus.MascotAdopted(userName, mascotName);
            System.Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
            System.Console.Clear();
            choice = true;
            break;
          case 3:
            choice = true;
            System.Console.Clear();
            break;
          default:
            break;
        }
      }
      catch (FormatException e)
      {
        System.Console.Clear();
        System.Console.WriteLine("Utilize apenas números");
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("Pressione uma tecla para continuar...");
        System.Console.ReadKey();
        break;
      }

    }
  }

  private static async Task<string> GetPokemonDescriptionAsync(string mascotName)
  {
    var pokemonDescription = await GetPokemon.GetPokemonDescription(mascotName);
    var mascot = JsonSerializer.Deserialize<Mascot>(pokemonDescription);

    return mascot.ToString();
  }

  private bool ValidateUserName(string? userName)
  {
    if (string.IsNullOrEmpty(userName))
    {
      throw new ArgumentNullException("Por favor, diga seu nome.");
    }

    if (userName.Length < 3 || userName.Length > 15)
    {
      throw new ArgumentOutOfRangeException("O nome deve ter no mínimo 3 e no máximo 15 caracteres");
    }

    return true;
  }

  private static bool InvalidInputOptions(string? response)
  {
    if (String.IsNullOrEmpty(response))
    {
      System.Console.WriteLine("Digite o número correspondente a opção");
      return true;
    }
    return false;
  }

}