using Application.Interfaces;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace Application.UnitTests
{
    public class TransactionReportServicesTests
    {
        ITransactionReportServices _transactionReportServices;
        IDataTransactionServices _dataTransactionServices;
        IDataAccountServices _dataAccountServices;

        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettingsTestingVersion.json", optional: false, reloadOnChange: true).Build();

            _dataTransactionServices = new JSONDataTransactionServices(configuration);
            _dataAccountServices = new JSONDataAccountServices(configuration);
            _transactionReportServices = new TransactionReportServices(_dataTransactionServices, _dataAccountServices);
        }


        [Test]
        public void GetTransactionReportFromLastMonthGroupedByCategory()
        {
            var transactionReports = _transactionReportServices.GetTransactionReportFromLastMonthGroupedByCategory("NL69INGB0123456789");
            Assert.AreEqual(transactionReports.ToList().Count, 4);
        }

        [Test]
        public void GetTransactionReportFromLastMonthGroupedByCategoryWrongIBAN()
        {
            var transactionReports = _transactionReportServices.GetTransactionReportFromLastMonthGroupedByCategory("wrong IBAN");
            Assert.AreEqual(transactionReports.ToList().Count, 0);
        }
    }
}