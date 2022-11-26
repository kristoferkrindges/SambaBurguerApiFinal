using SambaBurguer.Models;

namespace SambaBurguer.Repository.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAllSale();
        Task<Sale> GetForId(int id);
        Task<Sale> Add(Sale sale);
        Task<Sale> Update(Sale sale, int id);
        Task<bool> Delete(int id);
    }
}
