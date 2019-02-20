using RocketStore.Domain.StoreContext.Entities;
using RocketStore.Domain.StoreContext.Repositories;

namespace RocketStore.Tests
{
    public class MockCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
        }
    }
}