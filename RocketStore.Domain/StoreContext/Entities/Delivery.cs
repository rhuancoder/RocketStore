using System;
using FluentValidator;
using RocketStore.Domain.StoreContext.Enums;
using RocketStore.Shared.Entities;

namespace RocketStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            // If the estimated date of delivery is in the past, do not deliver
            
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            // If the status is already delivered, you can not cancel

            Status = EDeliveryStatus.Canceled;
        }
    }
}