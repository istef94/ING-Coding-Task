using Application.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Enums;

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
            var lastMonthTransactions = _dataTransactionServices.GetTransactionsList().Where(
                x => DateTime.Now.AddMonths(-1) < x.TransactionDate && x.Iban.Equals(iban)
            ).ToList();

            var results = lastMonthTransactions.GroupBy(x => x.CategoryId)
                            .Select(x => new TransactionReport
                            {
                                TotalAmount = x.Sum(y => y.Amount),
                                CategoryName = Enum.GetName(typeof(TransactionCategoriesEnum), x.First().CategoryId),
                            });

            return results;
        }
    }
}
