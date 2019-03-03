using PurchaseOrderRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        List<IPurchaseOrderRule> _rules;
        private readonly IMembershipService _membershipService;
        private readonly IShippingService _shippingService;

        public PurchaseOrderService(IMembershipService membershipService, IShippingService shippingService)
        {
            _membershipService = membershipService;
            _shippingService = shippingService;

            _rules = new List<IPurchaseOrderRule>
            {
                new MembershipRule(_membershipService),
                new PhysicalProductRule(_shippingService)
            };
        }

        public void ProcessOrder(PurchaseOrder order)
        {          
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(order))
                    rule.Evaluate(order);
            }
        }
    }
}
