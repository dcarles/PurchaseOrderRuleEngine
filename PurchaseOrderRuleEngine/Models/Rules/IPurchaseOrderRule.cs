using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    public interface IPurchaseOrderRule
    {

        bool IsMatch(PurchaseOrder order);
        void Evaluate(PurchaseOrder order);

    }
}
