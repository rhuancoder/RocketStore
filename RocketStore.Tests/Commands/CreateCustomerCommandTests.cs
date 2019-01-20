using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using RocketStore.Domain.StoreContext.Entities;

namespace RocketStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
       

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Rhuan";
            command.LastName = "Carvalho";
            command.Document = "28659170377";
            command.Email = "rsjlcarvalho@gmail.com";
            command.Phone = "21999999991";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
