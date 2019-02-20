using RocketStore.Domain.StoreContext.Entities;
using RocketStore.Domain.StoreContext.Services;

namespace RocketStore.Tests
{
    public class MockEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}