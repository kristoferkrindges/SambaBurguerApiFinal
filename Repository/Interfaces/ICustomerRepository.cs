using SambaBurguer.Models;

namespace SambaBurguer.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetForId(int id);
        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer, int id);
        Task<bool> Delete(int id);
    }
}
