using PurchaseOrderRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrderRuleEngine.Services
{
    public interface IShippingService
    {
        void CreateShippingSlip(IProduct product, Customer customer);
    }
}
