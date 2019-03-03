using PurchaseOrderRuleEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    class PhysicalProductRule : IPurchaseOrderRule
    {
        private readonly IShippingService _shippingService;

        public PhysicalProductRule(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public void Evaluate(PurchaseOrder order)
        {
            foreach (var physicalProduct in order.Items.Where(i=> i.Product.IsPhysicalProduct))
            {
                _shippingService.CreateShippingSlip(physicalProduct.Product, order.Customer);
            }
        }

        public bool IsMatch(PurchaseOrder order)
        {
            return order.Items.Any(i => i.Product.IsPhysicalProduct);
        }
    }
}
