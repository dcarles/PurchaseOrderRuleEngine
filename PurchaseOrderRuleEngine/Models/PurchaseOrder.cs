using System;
using System.Collections.Generic;

namespace PurchaseOrderRuleEngine.Models
{
    public class PurchaseOrder
    {
        public int PONumber { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public List<PurchaseOrderItem> Items { get; }

        public PurchaseOrder()
        {
            Items = new List<PurchaseOrderItem>();
        }

        public void AddItem(PurchaseOrderItem item)
        {
            Items.Add(item);
        }

    }
}
