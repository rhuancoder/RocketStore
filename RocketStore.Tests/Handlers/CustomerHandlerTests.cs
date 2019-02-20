using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using RocketStore.Domain.StoreContext.Entities;
using RocketStore.Domain.StoreContext.Handlers;

namespace RocketStore.Tests
{
    [TestClass]
    public class CustomerHandlerTests
    {
       

        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Rhuan";
            command.LastName = "Carvalho";
            command.Document = "28659170377";
            command.Email = "rsjlcarvalho@gmail.com";
            command.Phone = "21999999991";

            var handler = new CustomerHandler(new MockCustomerRepository(), new MockEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}
