using PurchaseOrderRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrderRuleEngine.Services
{
    public interface IPurchaseOrderService
    {
        void ProcessOrder(PurchaseOrder order);
    }
}
