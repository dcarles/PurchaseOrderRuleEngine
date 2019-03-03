using PurchaseOrderRuleEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    public class MembershipRule : IPurchaseOrderRule
    {
        private readonly IMembershipService _membershipService;

        public MembershipRule(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public void Evaluate(PurchaseOrder order)
        {
            var membership = order.Items.SingleOrDefault(i => i.Product is Membership);

            if (membership != null)
                _membershipService.ActivateMembership((Membership)membership.Product, order.Customer);

        }

        public bool IsMatch(PurchaseOrder order)
        {
            return order.Items.Any(i => i.Product is Membership);
        }
    }
}
