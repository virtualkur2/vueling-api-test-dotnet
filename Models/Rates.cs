using System;
using System.Net.Http;
using System.Threading.Tasks;

//TODO: Inject URI resource from config variable - Call persistence data

public class Rates : ITransactions
{
  public string Get
  {
    get
    {
      Task<string> rates = GetRates();
      return rates.Result;
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
        return $"Error getting transactions: {message}";
      }
    }
  }
}
