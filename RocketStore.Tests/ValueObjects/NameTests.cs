using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketStore.Domain.StoreContext.Entities;
using RocketStore.Domain.StoreContext.ValueObjects;

namespace RocketStore.Tests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Carvalho");
            Assert.AreEqual(false, name.IsValid);
        }
    }
}
