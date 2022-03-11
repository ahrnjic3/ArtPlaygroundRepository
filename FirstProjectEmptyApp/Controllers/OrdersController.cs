using FirstProjectEmptyApp.Data;
using FirstProjectEmptyApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectEmptyApp.Controllers
{

    [Route("api/[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IArtPlaygroundRepository repository;

        public OrdersController(IArtPlaygroundRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult Get() {
            try
            {
                return Ok(this.repository.GetAllOrders());
            }
            catch (Exception ex) {
                Console.WriteLine("Error when getting orders" + ex.Message);
                return BadRequest("Request failed");
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult Get(int id) {
            try
            {
                var order = this.repository.GetOrderById(id);

                Console.WriteLine("Order: " + order);
                if (order != null) return Ok(order);
                else return NotFound("Order with the given ID can't be found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when getting the order: " + ex.Message);
                return BadRequest("RequestFailed");
            }
        }
        [HttpPost]
        public IActionResult Post( [FromBody] Order model) {

            try
            {
                this.repository.AddEntity(model);
                if(this.repository.SaveAll())  return Created($"/api/orders/{model.Id}", model);
            }
            catch (Exception ex) {
                Console.WriteLine("Error:" + ex.Message);
                return BadRequest();
            }
            return BadRequest("Failed to create a new Order");
        }

        
    }
}
