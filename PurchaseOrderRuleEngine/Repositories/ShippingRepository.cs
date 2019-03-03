using System;
using System.Collections.Generic;
using System.Text;
using PurchaseOrderRuleEngine.Models;
using System.Linq;

namespace PurchaseOrderRuleEngine.Repositories
{
    public class ShippingRepository : IShippingRepository
    {

        private List<ShippingSlip> shippingSlips;

        public ShippingRepository()
        {
            shippingSlips = new List<ShippingSlip>();
        }

        public IEnumerable<ShippingSlip> GetCustomerShippingSlips(Customer customer)
        {
            return shippingSlips.Where(s => s.Customer.CustomerID == customer.CustomerID);
        }

        public void SaveShippingSlip(ShippingSlip shippingSlip)
        {
            shippingSlips.Add(shippingSlip);
        }
    }
}
