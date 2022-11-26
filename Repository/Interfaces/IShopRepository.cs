using SambaBurguer.Models;

namespace SambaBurguer.Repository.Interfaces
{
    public interface IShopRepository
    {
        Task<List<Shop>> GetAllShop();
        Task<Shop> GetForId(int id);
        Task<Shop> Add(Shop customer);
        Task<Shop> Update(Shop customer, int id);
        Task<bool> Delete(int id);
    }
}
