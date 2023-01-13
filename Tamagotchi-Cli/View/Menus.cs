
public class Menus
{
  public static void Presentation()
  {
    System.Console.Clear();
    System.Console.WriteLine(
      @"
      
████████╗░█████╗░███╗░░░███╗░█████╗░░██████╗░░█████╗░████████╗░█████╗░██╗░░██╗██╗
╚══██╔══╝██╔══██╗████╗░████║██╔══██╗██╔════╝░██╔══██╗╚══██╔══╝██╔══██╗██║░░██║██║
░░░██║░░░███████║██╔████╔██║███████║██║░░██╗░██║░░██║░░░██║░░░██║░░╚═╝███████║██║
░░░██║░░░██╔══██║██║╚██╔╝██║██╔══██║██║░░╚██╗██║░░██║░░░██║░░░██║░░██╗██╔══██║██║
░░░██║░░░██║░░██║██║░╚═╝░██║██║░░██║╚██████╔╝╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║██║
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝░╚═════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝
      "
    );
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
  }

  private static string PokemonArts(string pokemonName)
  {
    PokemonArts pokemonArts = new();
    string art = pokemonArts.pokemon[pokemonName];
    return art;
  }

}
