using Application.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class TransactionReportServices : ITransactionReportServices
    {
        public IEnumerable<TransactionReport> GetTransactionReportFromLastMonthGroupedByCategory(string iban)
        {
            throw new NotImplementedException();
        }
    }
}
