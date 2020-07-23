using ImaginaryStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ImaginaryStore.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
      
        public Order()
        {
        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Status = status;
            Client = client;
            Moment = moment;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append("Order moment: ");
            text.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            text.AppendLine("Order status: " + Status);
            text.Append("Client: ");
            text.AppendLine(Client.Name + " (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") - " + Client.Email);
            text.AppendLine("\nOrder items: ");

            foreach (OrderItem item in Items) {
                text.Append(item.Product.Name + ", ");
                text.Append("$" + item.Price.ToString("F2", CultureInfo.InvariantCulture) + ", ");
                text.Append("Quantity: " + item.Quantity + ", ");
                text.AppendLine("Subtotal: $" + item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }

            text.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return text.ToString();
        }
    }
}
