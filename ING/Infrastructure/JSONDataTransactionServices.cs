using Application.Entities;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure
{
    public class JSONDataTransactionServices : IDataTransactionServices
    {
        private readonly IConfiguration config;

        public JSONDataTransactionServices(IConfiguration configuration)
        {
            config = configuration;
        }

        public IEnumerable<Transaction> GetTransactionsList()
        {
            try
            {
                string path = config.GetSection("TransactionFilePath").Value;
                var transactions = new List<Transaction>();

                if (File.Exists(path))
                {
                    transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(path));
                }

                return transactions;
            }
            catch (Exception e)
            {
                //Log
            }

            return null;
        }
    }
}
