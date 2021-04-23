using Application.Interfaces;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace Application.UnitTests
{
    public class DataAccountServicesTests
    {
        IDataAccountServices _dataAccountServices;

        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettingsTestingVersion.json", optional: false, reloadOnChange: true).Build();

            _dataAccountServices = new JSONDataAccountServices(configuration);
        }

        [Test]
        public void AccountDontExist()
        {
            var account = _dataAccountServices.GetAccountByIBAN("Don't exist");
            Assert.IsNull(account);
        }

        [Test]
        public void ReceiveAccountwithIBAN()
        {
            var account = _dataAccountServices.GetAccountByIBAN("NL69INGB0123456789");
            Assert.IsNotNull(account);
            Assert.AreEqual(account.Iban, "NL69INGB0123456789");
        }

        [Test]
        public void GetAccountsList()
        {
            var accountList = _dataAccountServices.GetAccountsList();
            Assert.AreEqual(accountList.ToList().Count, 1);
        }
    }
}