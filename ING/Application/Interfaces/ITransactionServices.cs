using Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    interface ITransactionServices
    {
        IEnumerable<Transaction> GetTransactionsList();
    }
}
