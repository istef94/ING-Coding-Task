using Application.Entities;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure
{
    public class JSONDataAccountServices : IDataAccountServices
    {
        private readonly IConfiguration config;

        public JSONDataAccountServices(IConfiguration configuration)
        {
            config = configuration;
        }

        public Account GetAccountByIBAN(string iban)
        {
            try
            {
                string path = config.GetSection("AccountFilePath").Value;
                var accounts = new List<Account>();

                if (File.Exists(path))
                {
                    accounts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(path));
                }

                return accounts.Where(x=> x.Iban.Equals(iban)).FirstOrDefault();
            }
            catch (Exception e)
            {
                //Log
            }

            return null;        }

        public IEnumerable<Account> GetAccountsList()
        {
            try
            {
                string path = config.GetSection("AccountFilePath").Value;
                var accounts = new List<Account>();

                if (File.Exists(path))
                {
                    accounts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(path));
                }

                return accounts;
            }
            catch (Exception e)
            {
                //Log
            }

            return null;
        }
    }
}
