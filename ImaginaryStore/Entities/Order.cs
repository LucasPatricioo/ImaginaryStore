using ImaginaryStore.Entities.Enums;
using System;
using System.Collections.Generic;

namespace ImaginaryStore.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order(DateTime moment, OrderStatus status, Client client) {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item) {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item) {
            Items.Remove(item);
        }
        public double Total() {
            double sum = 0;
            foreach (OrderItem item in Items) {
                sum += item.Price;
            }
            return sum;
        }
    }
}
