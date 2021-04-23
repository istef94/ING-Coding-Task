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
        ITransactionReportServices _transactionReportServices;

        public TransactionsController(ITransactionReportServices transactionReportServices)
        {
            _transactionReportServices = transactionReportServices;
        }

        [HttpGet]
        [Route("report")]
        public IEnumerable<TransactionReport> Get(string iban)
        {
            return _transactionReportServices.GetTransactionReportFromLastMonthGroupedByCategory(iban);
        }
    }
}
