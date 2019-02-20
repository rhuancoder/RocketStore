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

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new MockCustomerRepository(), new MockEmailService());
        }
    }
}
