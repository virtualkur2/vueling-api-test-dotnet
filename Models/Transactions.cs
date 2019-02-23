using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Transactions : ITransactions
{
  public string Get
  {
    get
    {
      Task<string> transactions = GetTransactions();
      return transactions.Result;
    }
  }

  public async Task<string> GetTransactions()
  {
    using (var client = new HttpClient())
    {
      try
      {
        client.BaseAddress = new Uri("http://quiet-stone-2094.herokuapp.com/");
        var response = await client.GetAsync("transactions.json");
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
