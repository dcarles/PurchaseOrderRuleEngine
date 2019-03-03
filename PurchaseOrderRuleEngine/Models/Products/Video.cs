using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    public class Video : IProduct
    {
        public int ProductID { get ; set ; }
        public string Name { get ; set ; }     

        public bool IsPhysicalProduct => false;
    }
}
