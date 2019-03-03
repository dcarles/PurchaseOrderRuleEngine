using PurchaseOrderRuleEngine.Models;
using PurchaseOrderRuleEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderRuleEngine.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IShippingRepository _repository;

        public ShippingService(IShippingRepository repository)
        {
            _repository = repository;
        }

        public void CreateShippingSlip(IProduct product, Customer customer)
        {

            var shippingSlip = new ShippingSlip
            {
                Customer = customer,
                Product = product,
                ShippingAddress = customer.ShippingAddress
            };

            _repository.SaveShippingSlip(shippingSlip);


        }

    }
}
