using ProgramowanieRozproszone.Models;
using ProgramowanieRozproszone.Repositories;

namespace ProgramowanieRozproszone.Services
{
    public class OrderService
    {
        private OrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }
        public List<Order> GetOrders()
        {
            var orders = _orderRepository.GetOrders();

            var orderlist = orders
                .GroupBy(l => l.OrderId)
                .Select(d => new Order
                {
                    OrderId = d.First().OrderId,
                    OrderDate = d.First().OrderDate,
                    Client = new Client
                    {
                        ClientId = d.First().ClientId,
                        ClientName = d.First().ClientName,
                        ClientAddress = d.First().ClientAddress
                    },
                    Products = new List<Product>()
                }).ToList();
            foreach(var order in orders)
            {
                var product = new Product { ProductId = order.ProductId, ProductName = order.ProductName, ProductPrice = order.ProductPrice };
                orderlist.First(o => o.OrderId == order.OrderId).Products.Add(product);
            }

            return orderlist;

        }
    }
}
