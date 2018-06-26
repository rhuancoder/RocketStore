using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using RocketStore.Domain.StoreContext.Enums;

namespace RocketStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"{product.Title} product does not have {quantity} items in stock.");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        // To place an order
        public void Place()
        {
            // Generate the number of the order
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            // Validate
            if (_items.Count == 0)
                AddNotification("Order", "This order has no items");

        }

        // Pay an order
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        // Ship an order
        public void Ship()
        {
            // Every 5 products is a delivery
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            // Break the deliveries
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            // Ship all the deliveries
            deliveries.ForEach(x => x.Ship());

            // Add the deliveries to the order
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        // Cancel an order
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}