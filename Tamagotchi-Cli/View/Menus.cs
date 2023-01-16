
using SevenDaysOfCode.TamagotchiCli.Model;
using SevenDaysOfCode.TamagotchiCli.View.AscArt;

public class Menus
{
  public static void Presentation()
  {
    System.Console.Clear();
    System.Console.WriteLine(MainLogo.logo);
    System.Console.WriteLine(" ");
    System.Console.WriteLine(" ");
  }

  public static void Login()
  {
    System.Console.WriteLine("---------------- START ---------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine("Qual é o seu nome?");
  }

  public static void WelcomeMenu(string userName)
  {
    userName = userName.ToUpper();
    System.Console.WriteLine();
    System.Console.WriteLine("----------------- MENU ---------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine($"Olá {userName}, você deseja:");
    System.Console.WriteLine("1 - Adotar um mascote virtual");
    System.Console.WriteLine("2 - Ver seus mascotes");
    System.Console.WriteLine("3 - Sair ");

  }

  public static void ChooseMascotList(string userName)
  {
    userName = userName.ToUpper();
    System.Console.WriteLine();
    System.Console.WriteLine("------------ ADOTAR MASCOTE ----------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine($"{userName}, escolha uma espécie:");
    System.Console.WriteLine("1 - Bubasaur");
    System.Console.WriteLine("2 - Chamander");
    System.Console.WriteLine("3 - Squirtle ");
    System.Console.WriteLine("4 - Pikachu ");
    System.Console.WriteLine("5 - Zubat ");

  }

  public static void MascotMenu(string userName, string pokemonName)
  {
    System.Console.WriteLine(PokemonArts(pokemonName));
    userName = userName.ToUpper();
    pokemonName = pokemonName.ToUpper();
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine($"{userName}, você deseja:");
    System.Console.WriteLine($"1 - Ver a descrição de {pokemonName}");
    System.Console.WriteLine($"2 - Adotar {pokemonName}");
    System.Console.WriteLine("3 - Voltar ");
  }

  public static void MascotDescription(string pokemonDescription)
  {
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine(pokemonDescription);
    System.Console.WriteLine(" ");
  }

  public static void MascotAdopted(string userName, string pokemonName)
  {
    userName = userName.ToUpper();
    pokemonName = pokemonName.ToUpper();
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine($"{userName}, seu {pokemonName} foi adotado com sucesso!");
    System.Console.WriteLine($"O ovo está chocando:");
    System.Console.WriteLine(@"
                                                           
                                ████████                                  
                              ██        ██                                
                            ██▒▒▒▒        ██                              
                          ██▒▒▒▒▒▒      ▒▒▒▒██                            
                          ██▒▒▒▒▒▒      ▒▒▒▒██                            
                        ██  ▒▒▒▒        ▒▒▒▒▒▒██                          
                        ██                ▒▒▒▒██                          
                      ██▒▒      ▒▒▒▒▒▒          ██                        
                      ██      ▒▒▒▒▒▒▒▒▒▒        ██                        
                      ██      ▒▒▒▒▒▒▒▒▒▒    ▒▒▒▒██                        
                      ██▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒██                        
                        ██▒▒▒▒  ▒▒▒▒▒▒    ▒▒▒▒██                          
                        ██▒▒▒▒            ▒▒▒▒██                          
                          ██▒▒              ██                            
                            ████        ████                              
                                ████████
    ");
    System.Console.WriteLine("Pressione uma tecla para continuar...");
    Console.ReadKey();
  }

  public static void ShowMyMascotsList(List<Pokemon> adoptedMascots)
  {

    if (!adoptedMascots.Any())
    {
      System.Console.WriteLine();
      System.Console.WriteLine("----------- Não há Mascotes ----------");
      System.Console.WriteLine("Você ainda não adotou nenhum mascote.");
      System.Console.WriteLine(" ");
      return;
    }


    System.Console.WriteLine();
    System.Console.WriteLine("------------ Meus Mascotes ----------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine("Selecione um mascote para ver mais sobre ele");
    System.Console.WriteLine("0 - Voltar");
    foreach (var (mascot, index) in adoptedMascots.Select((Mascot, index) => (Mascot, index)))
    {
      System.Console.WriteLine($"{index + 1} - {mascot.name}");
    }
    System.Console.WriteLine(" ");

  }

  public static void ShowMyMascotMenu(string userName, string pokemonName)
  {
    System.Console.WriteLine(PokemonArts(pokemonName));
    userName = userName.ToUpper();
    pokemonName = pokemonName.ToUpper();
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine($"{userName}, você deseja:");
    System.Console.WriteLine($"1 - Saber como {pokemonName} está");
    System.Console.WriteLine($"2 - Alimentar o {pokemonName}");
    System.Console.WriteLine($"3 - Brincar com {pokemonName} ");
    System.Console.WriteLine("4 - Voltar");
  }

  public static void ShowPokemonHealth(string pokemonName, string pokemonDescription, string pokemonHungry, string pokemonMood, int pokemonAge)
  {
    pokemonName = pokemonName.ToUpper();
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine(pokemonDescription);
    System.Console.WriteLine($"{pokemonAge} anos em Mascote Virtual");
    System.Console.WriteLine($"{pokemonName} {pokemonHungry}");
    System.Console.WriteLine($"{pokemonName} {pokemonMood}");
    System.Console.WriteLine(" ");
    System.Console.WriteLine("Pressione uma tecla para continuar...");
    System.Console.ReadKey();
  }

  public static void HappyMascotFace(string message)
  {
    System.Console.WriteLine();
    System.Console.WriteLine("-------------------------------------");
    System.Console.WriteLine(" ");
    System.Console.WriteLine(" ( = ^ w ^ =) ");
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
    System.Console.WriteLine(message);
    System.Console.WriteLine(" ");
    System.Console.WriteLine("Pressione uma tecla para continuar...");
    System.Console.ReadKey();
  }
  public static void ShowErrorMessage(string message)
  {
    System.Console.Clear();
    System.Console.WriteLine(message);
    System.Console.WriteLine("Pressione uma tecla para continuar...");
    System.Console.ReadKey();
  }
  private static string PokemonArts(string pokemonName)
  {
    PokemonArts pokemonArts = new();
    string art = pokemonArts.pokemon[pokemonName];
    return art;
  }

}
