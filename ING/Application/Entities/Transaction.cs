using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Transaction
    {
        public string Iban { get; set; }
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
