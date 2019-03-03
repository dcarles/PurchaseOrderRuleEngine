using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    public class Book:IProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; }    
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }


        public bool IsPhysicalProduct => true;
    }
}
