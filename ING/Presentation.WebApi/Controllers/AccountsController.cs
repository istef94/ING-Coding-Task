using Application.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        IDataAccountServices _JSONDataAccountServices;

        public AccountsController(IDataAccountServices jSONDataAccountServices)
        {
            _JSONDataAccountServices = jSONDataAccountServices;
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _JSONDataAccountServices.GetAccountsList();
        }
    }
}
