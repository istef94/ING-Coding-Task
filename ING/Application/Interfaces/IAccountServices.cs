using Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    interface IAccountServices
    {
        IEnumerable<Account> GetAccountsList();
    }
}
