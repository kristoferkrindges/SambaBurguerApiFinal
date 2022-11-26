using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SambaBurguer.Models;
using SambaBurguer.Repository;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        public ShopController(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Shop>>> GetAllSale()
        {
            List<Shop> shop = await _shopRepository.GetAllShop();
            return Ok(shop);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetForId(int id)
        {
            Shop shops = await _shopRepository.GetForId(id);
            return Ok(shops);
        }
        [HttpPost]
        public async Task<ActionResult<Shop>> Add([FromBody] Shop shop)
        {
            Shop newShop = await _shopRepository.Add(shop);
            return Ok(newShop);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Shop>> Update([FromBody] Shop shop, int id)
        {
            shop.Id = id;
            Shop newShop = await _shopRepository.Update(shop, id);
            return Ok(newShop);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shop>> Delete(int id)
        {
            bool del = await _shopRepository.Delete(id);
            return Ok(del);
        }
    }
}
