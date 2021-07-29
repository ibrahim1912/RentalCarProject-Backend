using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class FakePayment:IEntity
    {
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public string MounthOfExp { get; set; }
        public string YearOfExp { get; set; }
        public string CVC { get; set; }
        public int Amount { get; set; }
    }
}
