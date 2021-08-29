using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaPrimeiraApi.Entities;
using MinhaPrimeiraApi.Interfaces;
using MinhaPrimeiraApi.ViewModels;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;
        

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
        public ActionResult<ProductViewModel> Get(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
                return BadRequest();

            var productViewModel = new ProductViewModel(){
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
            return Ok(productViewModel);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult Post([FromBody]ProductViewModel productViewModel)
        {
            if(productViewModel ==null)
                return NotFound();

            var product = new Product(){
                Name = productViewModel.Name,
                Price = productViewModel.Price
            };
            
            _productRepository.Add(product);
            return CreatedAtAction("Get", new {id = product.Id}, product);
        }

        [HttpPut("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public ActionResult Put(int id, [FromBody]ProductViewModel productViewModel)
        {
           if (id != productViewModel.Id)
                return NotFound();

            var product = new Product(){
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price
            };

            _productRepository.Update(product);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public ActionResult<ProductViewModel> Delete(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
                return NotFound();

            _productRepository.Remove(product);

            var productViewModel = new ProductViewModel(){
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
            return productViewModel;
        }
    }
}