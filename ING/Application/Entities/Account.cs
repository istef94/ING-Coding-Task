using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Account
    {
        public Guid ResourceId { get; set; }
        public string Product { get; set; }
        public string Iban { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
    }
}
