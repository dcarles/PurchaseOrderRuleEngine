using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    public class PurchaseOrderItem
    {
        public IProduct Product { get; set; }
        public int Quantity { get; set; }

        public PurchaseOrderItem()
        {
            Quantity = 1;
        }
    }
}
