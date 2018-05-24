using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketStore.Domain.StoreContext.Entities;

namespace RocketStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer("Rhuan", "Carvalho", "999999999", "rsjlcarvalho@gmail.com", "999999999", "Developers street, 7");
            var o = new Order(c);
        }
    }
}
