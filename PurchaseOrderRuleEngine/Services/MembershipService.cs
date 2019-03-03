using PurchaseOrderRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Services
{
    public class MembershipService : IMembershipService
    {       
        public void ActivateMembership(Membership membership, Customer customer)
        {
            customer.ActiveMembership = membership;
        }
    }
}
