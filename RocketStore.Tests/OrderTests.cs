using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketStore.Domain.StoreContext.Entities;
using RocketStore.Domain.StoreContext.Enums;
using RocketStore.Domain.StoreContext.ValueObjects;

namespace RocketStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Rhuan", "Carvalho");
            var document = new Document("46718115533");
            var email = new Email("rsjlcarvalho@gmail.com");
            _customer = new Customer(name, document, email, "55219999991");
            _order = new Order(_customer);

            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Keyboard Gamer", "Keyboard Gamer", "keyboard.jpg", 100M, 10);
            _chair = new Product("Chair Gamer", "Chair Gamer", "chair.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "monitor.jpg", 100M, 10);
        }

        // I can create a new order
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // When creating a order, the status must be created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // When adding a new item, the quantity of items must change
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);

            Assert.AreEqual(2, _order.Items.Count);
        }

        // When adding a new item, must subtract the quantity of the product
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedItems()
        {
            _order.AddItem(_mouse, 5);

            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // When confirming order, must generate a number
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();

            Assert.AreNotEqual("", _order.Number);
        }

        // When paying a order, the status must be paid
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();

            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Given 10 products, there should be two deliveries
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // When canceling a order, the status must be canceled
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
             _order.Cancel();

            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // When canceling a order, must be canceled the deliveries
        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            _order.Cancel();

            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);   
            }
        }
    }
}