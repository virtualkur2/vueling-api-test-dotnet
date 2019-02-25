using System;
using Microsoft.AspNetCore.Mvc;

namespace vueling_api_test_netcore.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {

      [HttpGet]
      public string getTransactions()
      {
        Transactions _transactions = new Transactions();
        return _transactions.Get;
      }
    }
}
