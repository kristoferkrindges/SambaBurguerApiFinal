using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SambaBurguer.Models;
using SambaBurguer.Repository;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetAllSale()
        {
            List<Sale> sales = await _saleRepository.GetAllSale();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetForId(int id)
        {
            Sale sales = await _saleRepository.GetForId(id);
            return Ok(sales);
        }
        [HttpPost]
        public async Task<ActionResult<Sale>> Add([FromBody] Sale sale)
        {
            Sale newSale = await _saleRepository.Add(sale);
            return Ok(newSale);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Sale>> Update([FromBody] Sale sale, int id)
        {
            sale.Id = id;
            Sale newSale = await _saleRepository.Update(sale, id);
            return Ok(newSale);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sale>> Delete(int id)
        {
            bool del = await _saleRepository.Delete(id);
            return Ok(del);
        }
    }
}
