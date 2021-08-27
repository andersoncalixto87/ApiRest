using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaPrimeiraApi.Entities;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private static List<Product> products = new List<Product>(){
            new Product(1,"Laptop Dell 300", 2500.0M),
            new Product(2,"Laptop Dell 550", 2799.0M),
            new Product(3,"Laptop Dell 450", 2389.0M)
            };

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }       

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Get()
        {
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Get(int id)
        {
            var product = products.Where(p => p.Id ==id).FirstOrDefault();
            if (product == null)
                return BadRequest();
            return Ok(product);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult Post([FromBody]Product product)
        {
            products.Add(product);
            return CreatedAtAction("Post", products);
        }

        [HttpPut("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public ActionResult Put(int id, [FromBody]Product product)
        {
            products.Add(product);
            return NoContent();
        }
    }
}