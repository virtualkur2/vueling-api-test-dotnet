using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// This imports will be implemented in Transactions Model
//========================================================
using System.Net.Http;
// using Syste.Threading.Tasks;
//using Newtonsoft.Json;
// using Sytem.Collections.Generic;
// using System.Linq;
// =======================================================

namespace vueling_api_test_netcore.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
      [HttpGet]
      public async Task<IActionResult> Transactions()
      {
        using (var client = new HttpClient())
        {
          try
          {
            client.BaseAddress = new Uri("http://quiet-stone-2094.herokuapp.com/");
            var response = await client.GetAsync("transactions.json");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return Ok(result);
          }
          catch (HttpRequestException httpRequestException)
          {
            var message = httpRequestException.Message;
            return BadRequest("Error getting transactions: {message}");
          }
        }
      }
    }
}
