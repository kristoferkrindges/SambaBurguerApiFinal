using Microsoft.EntityFrameworkCore;
using SambaBurguer.Context;
using SambaBurguer.Models;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<Product> GetForId(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> Add(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product, int id)
        {
            Product productForId = await GetForId(id);
            if (productForId == null)
            {
                throw new Exception($"Product ID:{id} Not found in DB!");
            }
            productForId.Name = product.Name;
            productForId.Price = product.Price;
            productForId.Description = product.Description;
            productForId.ImageUrl = product.ImageUrl;

            _dbContext.Products.Update(productForId);
            await _dbContext.SaveChangesAsync();
            return productForId;
        }
        public async Task<bool> Delete(int id)
        {
            Product productForId = await GetForId(id);
            if (productForId == null)
            {
                throw new Exception($"Product ID:{id} Not found in DB!");
            }
            _dbContext.Products.Remove(productForId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
