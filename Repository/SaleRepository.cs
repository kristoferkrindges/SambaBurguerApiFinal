using Microsoft.EntityFrameworkCore;
using SambaBurguer.Context;
using SambaBurguer.Models;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Repository
{
    public class SalerRepository : ISaleRepository
    {
        private readonly AppDbContext _dbContext;
        public SalerRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<Sale> GetForId(int id)
        {
            return await
                (((((_dbContext.Sales.Include(x => x.Product))
                .Include(x => x.Customer))
                .Include(x => x.Employee))
                .FirstOrDefaultAsync(x => x.Id == id)));
            //return await _dbContext.Sales.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Sale>> GetAllSale()
        {
            //return await _dbContext.Sales.ToListAsync();
            return await 
                (((((_dbContext.Sales.Include(x => x.Product))
                .Include(x => x.Customer))
                .Include(x => x.Employee.Shop))
                .ToListAsync()));
        }

   
        public async Task<Sale> Add(Sale sale)
        {
            await _dbContext.Sales.AddAsync(sale);
            await _dbContext.SaveChangesAsync();
            return sale;
        }

        public async Task<Sale> Update(Sale sale, int id)
        {
            Sale saleForId = await GetForId(id);
            if (saleForId == null)
            {
                throw new Exception($"Sale ID:{id} Not found in DB!");
            }
            saleForId.ProductId = sale.ProductId;
            saleForId.CustomerId = sale.CustomerId;
            saleForId.EmployeeId = sale.EmployeeId;
            saleForId.Date = sale.Date;

            _dbContext.Sales.Update(saleForId);
            await _dbContext.SaveChangesAsync();
            return saleForId;
        }
        public async Task<bool> Delete(int id)
        {
            Sale saleForId = await GetForId(id);
            if (saleForId == null)
            {
                throw new Exception($"Sale ID:{id} Not found in DB!");
            }
            _dbContext.Sales.Remove(saleForId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
