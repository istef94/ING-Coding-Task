using Application.Interfaces;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace Application.UnitTests
{
    public class DataTransactionServicesTests
    {
        IDataTransactionServices _dataAccountServices;

        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettingsTestingVersion.json", optional: false, reloadOnChange: true).Build();

            _dataAccountServices = new JSONDataTransactionServices(configuration);
        }


        [Test]
        public void GetAccountsList()
        {
            var accountList = _dataAccountServices.GetTransactionsList();
            Assert.AreEqual(accountList.ToList().Count, 14);
        }
    }
}