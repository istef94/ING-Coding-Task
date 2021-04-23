using Application.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Application.Enums;

namespace Infrastructure
{
    public class TransactionReportServices : ITransactionReportServices
    {
        private readonly IDataTransactionServices _dataTransactionServices;
        private readonly IDataAccountServices _dataAccountServices;

        public TransactionReportServices(IDataTransactionServices dataTransactionServices, IDataAccountServices dataAccountServices)
        {
            _dataTransactionServices = dataTransactionServices;
            _dataAccountServices = dataAccountServices;
        }

        public IEnumerable<TransactionReport> GetTransactionReportFromLastMonthGroupedByCategory(string iban)
        {
            try
            {
                var lastMonthTransactions = _dataTransactionServices.GetTransactionsList()?.Where(
                    x => DateTime.Now.AddMonths(-1) < x.TransactionDate && x.Iban.Equals(iban)
                )?.ToList();

                var account = _dataAccountServices.GetAccountByIBAN(iban);

                var results = lastMonthTransactions.GroupBy(x => x.CategoryId)?
                                .Select(x => new TransactionReport
                                {
                                    TotalAmount = x.Sum(y => y.Amount),
                                    CategoryName = Enum.GetName(typeof(TransactionCategoriesEnum), x.First().CategoryId),
                                    Currency = account?.Currency
                                })?.ToList();

                return results;
            }
            catch (Exception e)
            {
                //Log
            }

            return null;
        }
    }
}
