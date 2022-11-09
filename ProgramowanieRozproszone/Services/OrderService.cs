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

        public IEnumerable<DbOrder> GetDbOrders()
        {
            return _orderRepository.GetOrders().Concat(_orderRepository.GetOrders2());
        }
        public IEnumerable<BdOrderToProduct> GetOrderProductMap()
        {
            return _orderRepository.GetOrderProductMap().Concat(_orderRepository.GetOrderProductMap2());
        }
        public List<Order> GetOrders()
        {
            //var clients = new ClientService().GetClients();
            //var products = new ProductService().GetProducts();
            //var dborders = this.GetDbOrders();
            //var ordermap = this.GetOrderProductMap();

            //List<Order> orders = new List<Order>();


            //foreach(var o in dborders)
            //{
            //    Order order = new Order();
            //    order.OrderId = o.OrderId;
            //    order.OrderDate = o.OrderDate;
            //    order.Client = clients.Where(c => c.ClientId == o.ClientId).First();
            //    order.Products = new List<Product>();
            //    foreach(var p in ordermap)
            //    {
            //        if(p.OrderId == order.OrderId)
            //        {
            //            order.Products.Add(products.Where(a => a.ProductId == p.ProductId).First());
            //        }
            //    }
            //    orders.Add(order);
            //}

            //return orders;
            return new List<Order>()
            {
                new Order()
                {
                    OrderId = 1,
                    OrderDate = DateTime.Now,
                    Client = new ClientService().GetClients().First(),
                    Products = new List<Product>()
                    {
                        new ProductService().GetProducts().First()
                    }
                }
            };

        }
        public void DeleteOrder(int OrderId)
        {
            //try
            //{
            //    _orderRepository.DeleteOrder(OrderId);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            //try
            //{
            //    _orderRepository.DeleteOrder2(OrderId);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
        }
        public void UpdateOrder(Order order)
        {
            //try
            //{
            //    _orderRepository.UpdateOrder(order);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            //try
            //{
            //    _orderRepository.UpdateOrder2(order);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
        }
        public void PostOrder(Order order)
        {
            //var maxId1 = _orderRepository.maxId();
            //var maxId2 = _orderRepository.maxId2();
            //if (maxId1 >= maxId2)
            //{
            //    //order.OrderId = maxId1;
            //    _orderRepository.InsertOrder2(order);
            //}
            //else
            //{
            //    order.OrderId = maxId2;
            //    _orderRepository.InsertOrder(order);
            //}
        }
    }
}
