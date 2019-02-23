using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Rates : IRates
{
  public string Get
  {
    get
    {
      Task<string> result = GetRates();
    }
  }

  public async Task<string> GetRates()
  {
    using (var client = new HttpClient())
    {
      try
      {
        client.BaseAddress = new Uri("http://quiet-stone-2094.herokuapp.com/");
        var response = await client.GetAsync("rates.json");
        response.EnsureSuccessStatusCode();
        string result = await response.Content.ReadAsStringAsync();
        return result;
      }
      catch (HttpRequestException httpRequestException)
      {
        string message = httpRequestException.Message;
        return "Error getting transactions: {message}";
      }
    }
  }
}
