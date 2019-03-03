using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    public interface IProduct
    {
        int ProductID { get; set; }
        String Name { get; set; }      
        bool IsPhysicalProduct { get; }
    }
}
