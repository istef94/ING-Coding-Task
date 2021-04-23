using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class TransactionReport
    {
        public string CategoryName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
    }
}
