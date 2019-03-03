using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public String Name { get; set; }
        public String EmailAddress { get; set; }
        public String BillingAddress { get; set; }
        public String ShippingAddress { get; set; }

        public Membership ActiveMembership { get; set; }
    }
}
