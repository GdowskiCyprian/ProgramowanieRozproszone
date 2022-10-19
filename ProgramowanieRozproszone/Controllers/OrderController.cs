﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramowanieRozproszone.Models;
using ProgramowanieRozproszone.Services;

namespace ProgramowanieRozproszone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }
        [HttpGet]
        public List<Order> GetAllOrders()
        {
            return _orderService.GetOrders();
        }
        [HttpPost]
        public void PostOrder([FromBody] Order order)
        {
            //add new order to database
        }
        
        [HttpPut]
        public void PutOrder([FromBody] Order order)
        {
            //modify order
        }
        [HttpDelete]
        public void DeleteOrder(int OrderId)
        {
            //delete order
        }

    }
}
