
using SevenDaysOfCode.TamagotchiCli.Service;
using SevenDaysOfCode.TamagotchiCli.Model;

public class TamagotchiController
{
  private string? _userName = String.Empty;
  private string? _mascotName = String.Empty;
  private readonly TamagotchiService _tamagotchiService;

  public TamagotchiController(TamagotchiService tamagotchiService)
  {
    _tamagotchiService = tamagotchiService;
  }


  public void LoginMenu()
  {
    bool opt = false;
    while (opt == false)
    {
      try
      {
        Menus.Presentation();
        Menus.Login();
        _userName = Console.ReadLine();

        opt = _tamagotchiService.ValidateUserName(_userName);
      }
      catch (ArgumentNullException e)
      {
        Menus.ShowErrorMessage(e.Message);
      }
      catch (ArgumentOutOfRangeException e)
      {
        Menus.ShowErrorMessage(e.Message);
      }

    }
  }

  public async Task MainMenuAsync()
  {

    bool menuOption = false;
    while (menuOption == false)
    {
      try
      {
        Menus.WelcomeMenu(_userName!);
        var response = Console.ReadLine();
        if (_tamagotchiService.InvalidInputOptions(response)) continue;

        int option = Convert.ToInt32(response);

        switch (option)
        {
          case 1:
            System.Console.Clear();
            Menus.ChooseMascotList(_userName);
            var opt = Console.ReadLine();

            if (_tamagotchiService.InvalidInputOptions(opt)) continue;

            _mascotName = _tamagotchiService.SelectPokemonName(opt);

            if (!String.IsNullOrEmpty(_mascotName))
            {
              await MascotMenuAsync(_userName, _mascotName, _tamagotchiService);
            }
            break;
          case 2:
            System.Console.Clear();
            Menus.ShowMyMascotsList(_tamagotchiService.GetMascotsList());
            if (_tamagotchiService.GetMascotsList().Any())
            {

              var pokemon = AdoptedMascotsMenu(_userName, _mascotName, _tamagotchiService);

              if (string.IsNullOrEmpty(pokemon.name))
              {
                break;
              }

              AdoptedMascotsMenuOptions(_userName, pokemon, _tamagotchiService);


            }
            break;
          case 3:
            menuOption = true;
            break;
          default:
            Menus.ShowErrorMessage("Opção não encontrada");
            break;
        }
      }
      catch (FormatException)
      {
        Menus.ShowErrorMessage("Utilize apenas números");

      }
      catch (ArgumentNullException e)
      {
        System.Console.Clear();
        System.Console.WriteLine(e.StackTrace);
        System.Console.WriteLine(e.Message);
        break;
      }
      catch (ArgumentOutOfRangeException e)
      {
        Menus.ShowErrorMessage(e.Message);
      }
    }

  }

  private static async Task MascotMenuAsync(string userName, string mascotName, TamagotchiService tamagotchiService)
  {
    var goBack = false;
    while (goBack == false)
    {
      try
      {
        System.Console.Clear();
        Menus.MascotMenu(userName, mascotName);
        var mascotMenuOpt = Console.ReadLine();

        if (String.IsNullOrEmpty(mascotMenuOpt))
        {
          Menus.ShowErrorMessage(" Não entendi sua resposta, pode repetir? ");
          continue;
        }

        int opt = Convert.ToInt32(mascotMenuOpt);

        if (opt <= 0 || opt >= 4)
        {
          Menus.ShowErrorMessage(" Opção inválida.");
          continue;
        }
        Mascot pokemon;
        switch (opt)
        {
          case 1:
            pokemon = await tamagotchiService.GetPokemonDescriptionAsync(mascotName);

            if (pokemon is null)
            {
              Menus.ShowErrorMessage("Dados inacessíveis no momento.");
              break;
            }

            Menus.MascotDescription(pokemon.ToString());
            System.Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
            break;

          case 2:
            pokemon = await tamagotchiService.GetPokemonDescriptionAsync(mascotName);

            if (pokemon is null)
            {
              Menus.ShowErrorMessage("Dados inacessíveis no momento.");
              break;
            }

            if (tamagotchiService.IsMascotAlreadAdopted(pokemon))
            {
              Menus.ShowErrorMessage("Você já adotou esse pokemon.");
              break;
            }

            tamagotchiService.AdoptMascot(pokemon);

            Menus.MascotAdopted(userName, pokemon.name);

            System.Console.Clear();
            goBack = true;
            break;

          case 3:
            goBack = true;
            System.Console.Clear();
            break;
          default:
            break;
        }
      }
      catch (FormatException e)
      {
        Menus.ShowErrorMessage("Utilize apenas números");
        continue;
      }
    }
  }


  private static Mascot? AdoptedMascotsMenu(string userName, string mascotName, TamagotchiService tamagotchiService)
  {
    Mascot pokemon = new Mascot();

    bool goBack = false;
    while (goBack == false)
    {
      try
      {
        var response = System.Console.ReadLine();

        var opt = Convert.ToInt32(response);
        if (opt.Equals(0))
        {
          return pokemon;
        }

        if (opt < 0 || opt > tamagotchiService.GetMascotsList().Count())
        {
          Menus.ShowErrorMessage($"{opt} não é uma opção válida");
          break;
        }


        var pokemonsList = tamagotchiService.GetMascotsList();
        pokemon = pokemonsList[opt - 1];

        if (pokemon is null)
        {
          Menus.ShowErrorMessage($"Desculpe, não consegui encontra-lo.");
          break;
        }

        return pokemon;
      }
      catch (ArgumentException e)
      {
        System.Console.Clear();
        System.Console.WriteLine(e.StackTrace);
        System.Console.WriteLine(e.Message);
      }
    }

    return pokemon;
  }

  private static void AdoptedMascotsMenuOptions(string _userName, Mascot pokemon, TamagotchiService _tamagotchiService)
  {
    bool goBack = false;
    while (goBack == false)
    {

      System.Console.Clear();
      Menus.ShowMyMascotMenu(_userName, pokemon.name);
      var response = System.Console.ReadLine();
      if (_tamagotchiService.InvalidInputOptions(response)) continue;

      var opt = Convert.ToInt32(response);

      switch (opt)
      {
        case 1:
          Menus.ShowPokemonHealth(pokemon.name, pokemon.ToString(), pokemon.PokemonHungry(), pokemon.PokemonMood(), pokemon.Age);
          break;
        case 2:
          if (_tamagotchiService.FeedPokemon(pokemon))
          {
            Menus.HappyMascotFace($"{pokemon.name} foi alimentado.");
            break;
          }
          Menus.HappyMascotFace($"{pokemon.name} já está satisfeito");
          break;
        case 3:
          if (_tamagotchiService.PlayWithPokemon(pokemon))
          {
            Menus.HappyMascotFace($"Você brincou com {pokemon.name} e ele ficou contente.");
            break;
          }
          Menus.SadMascotFace($"Parece que {pokemon.name} está com muita fome");
          break;
        case 4:
          goBack = true;
          break;

        default:
          Menus.ShowErrorMessage("Opção não encontrada");
          break;
      }

    }


  }
}