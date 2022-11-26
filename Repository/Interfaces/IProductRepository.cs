using SambaBurguer.Models;

namespace SambaBurguer.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetForId(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product, int id);
        Task<bool> Delete(int id);
    }
}
