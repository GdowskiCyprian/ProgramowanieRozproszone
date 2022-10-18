using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramowanieRozproszone.Models;

namespace ProgramowanieRozproszone.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            IEnumerable<Order> orders = new List<Order>();
            return orders;
        }
        [HttpPost]
        public void PostOrder([FromBody] Order order)
        {
            //add new order to database
        }
        //modify order

        //delete order
    }
}
