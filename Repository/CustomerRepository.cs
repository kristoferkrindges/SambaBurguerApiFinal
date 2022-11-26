using Microsoft.EntityFrameworkCore;
using SambaBurguer.Context;
using SambaBurguer.Models;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        public CustomerRepository(AppDbContext appDbContext) {
            _dbContext = appDbContext;
        }
        public async Task<Customer> GetForId(int id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> Add(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> Update(Customer customer, int id)
        {
            Customer customerForId = await GetForId(id);
            if (customerForId == null) {
                throw new Exception($"Customer ID:{id} Not found in DB!");
            }
            customerForId.Name = customer.Name;
            customerForId.Gender = customer.Gender;
            customerForId.Cpf = customer.Cpf;
            customerForId.Email = customer.Email;
            customerForId.BirthDate = customer.BirthDate;
            customerForId.Address = customer.Address;
            customerForId.Cep = customer.Cep;
            customerForId.ImageUrl = customer.ImageUrl;

            _dbContext.Customers.Update(customerForId);
            await _dbContext.SaveChangesAsync();
            return customerForId;

        }
        public async Task<bool> Delete(int id)
        {
            Customer customerForId = await GetForId(id);
            if (customerForId == null)
            {
                throw new Exception($"Customer ID:{id} Not found in DB!");
            }
            _dbContext.Customers.Remove(customerForId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
