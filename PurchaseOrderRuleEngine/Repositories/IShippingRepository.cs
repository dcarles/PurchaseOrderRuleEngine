using PurchaseOrderRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Repositories
{
    public interface IShippingRepository
    {
        void SaveShippingSlip(ShippingSlip shippingSlip);
        IEnumerable<ShippingSlip> GetCustomerShippingSlips(Customer customer);
    }
}
