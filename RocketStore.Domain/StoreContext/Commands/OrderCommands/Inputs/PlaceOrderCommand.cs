using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using RocketStore.Shared.Commands;

namespace RocketStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
             OrderItems = new List<OrderItemCommand>();   
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(), 36, "Customer", "Client Id is invalid")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "None Order Item is found")
            );

            return IsValid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}