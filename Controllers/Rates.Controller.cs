using System;
using Microsoft.AspNetCore.Mvc;


namespace vueling_api_test_netcore.Controllers
{
    [Route("api/[controller]")]
    public class RatesController : Controller
    {
      [HttpGet]
      public string getRates()
      {
        Rates _rates = new Rates();
        return _rates.Get;
      }
    }
}
