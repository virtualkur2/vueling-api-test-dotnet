using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace vueling_api_test_netcore.Controllers
{
    [Route("api/[controller]")]
    public class RatesController : Controller
    {
      [HttpGet]
      public async Task<IActionResult> Transactions()
      {
        using (var client = new HttpClient())
        {
          try
          {
            client.BaseAddress = new Uri("http://quiet-stone-2094.herokuapp.com/");
            var response = await client.GetAsync("rates.json");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return Ok(result);
          }
          catch (HttpRequestException httpRequestException)
          {
            var message = httpRequestException.Message;
            return BadRequest("Error getting rates: {message}");
          }
        }
      }
    }
}
