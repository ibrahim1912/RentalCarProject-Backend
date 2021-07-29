using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment2:IEntity
    {
        public int Payment2Id { get; set; }
        public int CustomerId { get; set; }
        public string CreditCardNumber { get; set; }
        public decimal Price { get; set; }
        public string ExpirationDate { get; set; }

        public string CVV { get; set; }

    }
}
