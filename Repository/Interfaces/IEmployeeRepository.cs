using SambaBurguer.Models;

namespace SambaBurguer.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetForId(int id);
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee, int id);
        Task<bool> Delete(int id);
    }
}
