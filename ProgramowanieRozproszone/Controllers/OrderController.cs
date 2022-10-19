using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramowanieRozproszone.Models;

namespace ProgramowanieRozproszone.Controllers
{
    [ApiController]
    public class OrderController : Controller
    {
        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
            //
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
