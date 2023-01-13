namespace SevenDaysOfCode.TamagotchiCli;

public class GetPokemon
{
  async public static Task<string> GetPokemonDescription(string pokemon)
  {
    var client = new HttpClient();
    var request = new HttpRequestMessage();
    request.RequestUri = new Uri($"https://pokeapi.co/api/v2/pokemon/{pokemon}");
    request.Method = HttpMethod.Get;

    request.Headers.Add("Accept", "*/*");

    var response = await client.SendAsync(request);
    return await response.Content.ReadAsStringAsync();
  }
}