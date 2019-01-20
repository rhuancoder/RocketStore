using System;
using System.Collections.Generic;

namespace RocketStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand
    {
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> MyProperty { get; set; }
    }

    public class OrderItemCommand {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}