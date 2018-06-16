using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketStore.Domain.StoreContext.Entities;
using RocketStore.Domain.StoreContext.ValueObjects;

namespace RocketStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Rhuan", "Carvalho");
            var document = new Document("123456789");
            var email = new Email("test@test.com");
            var c = new Customer(name, document, email, "999999999");
            var mouse = new Product("Mouse", "Mouse XYZ", "image.png", 59.90M, 10);
            var keyboard = new Product("Keyboard", "Keyboard XYZ", "image.png", 159.90M, 10);
            var table = new Product("Table", "Table XYZ", "image.png", 559.90M, 10);
            var cable = new Product("Cable", "Cable XYZ", "image.png", 29.90M, 10);

            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(keyboard, 5));
            //order.AddItem(new OrderItem(table, 5));
            //order.AddItem(new OrderItem(cable, 5));

            // Order realized
            order.Place();

            // Verify that the order is valid
            var valid = order.IsValid;

            // Simulate the payment
            order.Pay();

            // Simulate the shipping
            order.Ship();

            // Simulate the cancellation
            order.Cancel();
        }
    }
}
