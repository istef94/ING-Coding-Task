using Application.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class TransactionReportServices : ITransactionReportServices
    {
        private readonly IDataTransactionServices _dataTransactionServices;

        public TransactionReportServices(IDataTransactionServices dataTransactionServices)
        {
            _dataTransactionServices = dataTransactionServices;
        }

        public IEnumerable<TransactionReport> GetTransactionReportFromLastMonthGroupedByCategory(string iban)
        {
            var result = new List<TransactionReport>();
            var transactions = _dataTransactionServices.GetTransactionsList();

            return result;
        }
    }
}
