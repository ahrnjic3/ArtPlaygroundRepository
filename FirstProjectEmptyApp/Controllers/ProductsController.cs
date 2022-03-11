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
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IArtPlaygroundRepository repository;

        public ProductsController(IArtPlaygroundRepository repository)
        {
            this.repository = repository;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        //[Route("get")]
        public ActionResult<IEnumerable<Product>> Get()
        {

            try
            {
                return Ok(this.repository.GetAllPRoducts());
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
                return BadRequest("Failed to Get products");
            }
        }
        
    }
}
