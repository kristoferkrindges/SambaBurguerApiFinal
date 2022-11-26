using Microsoft.EntityFrameworkCore;
using SambaBurguer.Context;
using SambaBurguer.Models;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly AppDbContext _dbContext;
        public ShopRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<Shop> GetForId(int id)
        {
            return await _dbContext.Shops.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Shop>> GetAllShop()
        {
            return await _dbContext.Shops.ToListAsync();
        }

        public async Task<Shop> Add(Shop shop)
        {
            await _dbContext.Shops.AddAsync(shop);
            await _dbContext.SaveChangesAsync();
            return shop;
        }
        public async Task<Shop> Update(Shop shop, int id)
        {
            Shop shoprForId = await GetForId(id);
            if (shoprForId == null)
            {
                throw new Exception($"Shop ID:{id} Not found in DB!");
            }
            shoprForId.State = shop.State;
            shoprForId.Cep = shop.Cep;
            shoprForId.City = shop.City;
            shoprForId.ImageUrl = shop.ImageUrl;


            _dbContext.Shops.Update(shoprForId);
            await _dbContext.SaveChangesAsync();
            return shoprForId;

        }
        public async Task<bool> Delete(int id)
        {
            Shop shoprForId = await GetForId(id);
            if (shoprForId == null)
            {
                throw new Exception($"Shop ID:{id} Not found in DB!");
            }
            _dbContext.Shops.Remove(shoprForId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
