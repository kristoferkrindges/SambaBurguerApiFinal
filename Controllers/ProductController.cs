using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SambaBurguer.Models;
using SambaBurguer.Repository;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllCustomers()
        {
            List<Product> Products = await _productRepository.GetAllProduct();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetForId(int id)
        {
            Product products = await _productRepository.GetForId(id);
            return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Add([FromBody] Product product)
        {
            Product newProduct = await _productRepository.Add(product);
            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update([FromBody] Product product, int id)
        {
            product.Id = id;
            Product newProduct = await _productRepository.Update(product, id);
            return Ok(newProduct);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            bool del = await _productRepository.Delete(id);
            return Ok(del);
        }
    }
}
