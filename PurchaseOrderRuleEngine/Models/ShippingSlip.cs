using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    public class ShippingSlip
    {

        public IProduct Product { get; set; }
        public Customer Customer { get; set; }
        public String ShippingAddress { get; set; }


    }
}
