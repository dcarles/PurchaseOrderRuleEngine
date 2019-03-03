using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Models
{
    public class Membership : IProduct
    {
        public int ProductID { get; set; }

        public string Name { get; set; }     
        public bool IsPhysicalProduct => false;
        public MembershipType Type { get; set; }
        public DateTime ExpirationDate { get; set; }

    }

    public enum MembershipType
    {
        BookClub,
        VideoClub,
        Premium
    }
}
