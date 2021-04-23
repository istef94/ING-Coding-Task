using Application.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        public TransactionsController( )
        {
        }

        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
          //  return _JSONDataAccountServices.GetAccountsList();
        }
    }
}
