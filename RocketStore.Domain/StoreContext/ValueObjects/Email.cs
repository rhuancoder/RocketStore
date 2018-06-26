using FluentValidator;
using FluentValidator.Validation;

namespace RocketStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "The E-mail is invalid")
            );
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}