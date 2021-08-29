using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaPrimeiraApi.Entities;
using MinhaPrimeiraApi.Interfaces;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;
        private static List<Product> productss = new List<Product>(){
            new Product(1,"Laptop Dell 300", 2500.0M),
            new Product(2,"Laptop Dell 550", 2799.0M),
            new Product(3,"Laptop Dell 450", 2389.0M)
            };

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }       

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Get()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Get(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
                return BadRequest();

            return Ok(product);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult Post([FromBody]Product product)
        {
            _productRepository.Add(product);
            return CreatedAtAction("Get", new {id = product.Id}, product);
        }

        [HttpPut("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public ActionResult Put(int id, [FromBody]Product product)
        {
           if (id != product.Id)
                return NotFound();

            _productRepository.Update(product);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public ActionResult<Product> Delete(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
                return NotFound();

            _productRepository.Remove(product);
            return product;
        }
    }
}