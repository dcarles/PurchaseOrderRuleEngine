using NUnit.Framework;
using System;
using PurchaseOrderRuleEngine.Models;
using PurchaseOrderRuleEngine.Services;
using PurchaseOrderRuleEngine.Repositories;
using System.Linq;

namespace PurchaseOrderRuleEngine.Tests.Unit
{
    [TestFixture]
    public class RulesTest
    {

        private IMembershipService _membershipService;
        private IShippingRepository _shippingRepository;
        private IShippingService _shippingService;
        private IPurchaseOrderService _purchaseOrderService;
        private PurchaseOrder _purchaseOrder;

        [SetUp]
        public void Init()
        {
            _membershipService = new MembershipService();
            _shippingRepository = new ShippingRepository();
            _shippingService = new ShippingService(_shippingRepository);
            _purchaseOrderService = new PurchaseOrderService(_membershipService, _shippingService);

            _purchaseOrder = new PurchaseOrder
            {
                PONumber = 123,
                TotalAmount = 557.5m,
                Customer = new Customer
                {
                    Name = "Daniel Carles",
                    CustomerID = 456,
                    ShippingAddress = "1 Chiltern Gardens, Bromley"
                }
            };

        }


        [Test]
        public void WhenPurchaseOrderContainsMembershipItShouldBeActivated()
        {
            _purchaseOrder.Items.Add(new PurchaseOrderItem
            {
                Product = new Membership
                {
                    Name = "Book Club Membership",
                    ProductID = 789,
                    ExpirationDate = DateTime.Now.AddYears(1),
                    Type = MembershipType.BookClub
                },
                Quantity = 1

            });

            _purchaseOrderService.ProcessOrder(_purchaseOrder);

            Assert.True(_purchaseOrder.Customer.ActiveMembership != null);

        }

        [Test]
        public void WhenPurchaseOrderContainsNoMembershipItShouldNotBeActivated()
        {
            _purchaseOrder.Items.Add(new PurchaseOrderItem
            {
                Product = new Video
                {
                    Name = "The art of unit testing",
                    ProductID = 789
                },
                Quantity = 1
            });

            _purchaseOrderService.ProcessOrder(_purchaseOrder);

            Assert.True(_purchaseOrder.Customer.ActiveMembership == null);

        }

        [Test]
        public void WhenPurchaseOrderContains1PhysicalProduct1ShippingSlipShouldBeCreated()
        {
            _purchaseOrder.Items.Add(new PurchaseOrderItem
            {
                Product = new Book
                {
                    Name = "Red Rising",
                    ProductID = 789,
                    Author = "Pierce Brown",
                    PublicationDate = new DateTime(2014, 1, 28)
                },
                Quantity = 1
            });

            _purchaseOrderService.ProcessOrder(_purchaseOrder);

            var shippingSlips = _shippingRepository.GetCustomerShippingSlips(_purchaseOrder.Customer);

            Assert.IsNotEmpty(shippingSlips);
            Assert.IsTrue(shippingSlips.Any(s => s.Product == _purchaseOrder.Items.First().Product));
            Assert.IsTrue(shippingSlips.Any(s => s.Customer == _purchaseOrder.Customer));
            Assert.IsTrue(shippingSlips.Any(s => s.ShippingAddress == _purchaseOrder.Customer.ShippingAddress));

        }

        [Test]
        public void WhenPurchaseOrderContains2PhysicalProduct2ShippingSlipsShouldBeCreated()
        {
            _purchaseOrder.Items.Add(new PurchaseOrderItem
            {
                Product = new Book
                {
                    Name = "Red Rising",
                    ProductID = 789,
                    Author = "Pierce Brown",
                    PublicationDate = new DateTime(2014, 1, 28)
                },
                Quantity = 1
            });

            _purchaseOrder.Items.Add(new PurchaseOrderItem
            {
                Product = new Book
                {
                    Name = "Golden Son",
                    ProductID = 567,
                    Author = "Pierce Brown",
                    PublicationDate = new DateTime(2015, 1, 6)
                },
                Quantity = 1
            });

            _purchaseOrderService.ProcessOrder(_purchaseOrder);

            var shippingSlips = _shippingRepository.GetCustomerShippingSlips(_purchaseOrder.Customer);

            Assert.IsNotEmpty(shippingSlips);
            Assert.IsTrue(shippingSlips.Count() == 2);
            Assert.IsTrue(shippingSlips.Any(s => s.Product == _purchaseOrder.Items.First().Product));
            Assert.IsTrue(shippingSlips.Any(s => s.Product == _purchaseOrder.Items.Last().Product));
            Assert.IsTrue(shippingSlips.Where(s => s.Customer == _purchaseOrder.Customer).Count() == 2);
            Assert.IsTrue(shippingSlips.Where(s => s.ShippingAddress == _purchaseOrder.Customer.ShippingAddress).Count() == 2);

        }

        [Test]
        public void WhenPurchaseOrderContainsNoPhysicalProductNoShippingSlipShouldBeCreated()
        {
            _purchaseOrder.Items.Add(new PurchaseOrderItem
            {
                Product = new Video
                {
                    Name = "The art of unit testing",
                    ProductID = 789   
                },
                Quantity = 1
            });

            _purchaseOrderService.ProcessOrder(_purchaseOrder);

            var shippingSlips = _shippingRepository.GetCustomerShippingSlips(_purchaseOrder.Customer);

            Assert.IsEmpty(shippingSlips);         

        }


        public void WhenPurchaseOrderContainsMembershipAndPhysicalProductBothRulesShouldBeExecuted()
        {
            _purchaseOrder.Items.Add(new PurchaseOrderItem
            {
                Product = new Book
                {
                    Name = "Red Rising",
                    ProductID = 789,
                    Author = "Pierce Brown",
                    PublicationDate = new DateTime(2014, 1, 28)
                },
                Quantity = 1
            });

            _purchaseOrder.Items.Add(new PurchaseOrderItem
            {
                Product = new Membership
                {
                    Name = "Book Club Membership",
                    ProductID = 789,
                    ExpirationDate = DateTime.Now.AddYears(1),
                    Type = MembershipType.BookClub
                },
                Quantity = 1

            });

            _purchaseOrderService.ProcessOrder(_purchaseOrder);

            var shippingSlips = _shippingRepository.GetCustomerShippingSlips(_purchaseOrder.Customer);

            Assert.IsNotEmpty(shippingSlips);
            Assert.IsTrue(shippingSlips.Any(s => s.Product == _purchaseOrder.Items.First().Product));
            Assert.IsTrue(shippingSlips.Any(s => s.Customer == _purchaseOrder.Customer));
            Assert.IsTrue(shippingSlips.Any(s => s.ShippingAddress == _purchaseOrder.Customer.ShippingAddress));

            Assert.True(_purchaseOrder.Customer.ActiveMembership != null);

        }


    }
}
