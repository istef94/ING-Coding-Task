using Application.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class JSONDataAccountServices : IDataAccountServices
    {
        public IEnumerable<Account> GetAccountsList()
        {
            throw new NotImplementedException();
        }
    }
}
