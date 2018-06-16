using FluentValidator;
using System;
using System.Collections.Generic;

namespace RocketStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Product out of stock");
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}