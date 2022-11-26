using Microsoft.EntityFrameworkCore;
using SambaBurguer.Context;
using SambaBurguer.Models;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<Employee> GetForId(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            //return await _dbContext.Employees.Include(x => x.Shop).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
            //return await _dbContext.Employees.Include(x => x.Shop).ToListAsync();
        }

        public async Task<Employee> Add(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Update(Employee employee, int id)
        {
            Employee employeeForId = await GetForId(id);
            if (employeeForId == null)
            {
                throw new Exception($"Employee ID:{id} Not found in DB!");
            }
            employeeForId.ShopId = employee.ShopId;
            employeeForId.Name = employee.Name;
            employeeForId.Address = employee.Address;
            employeeForId.BirthDate = employee.BirthDate;
            employeeForId.Email = employee.Email;
            employeeForId.Cpf = employee.Cpf;
            employeeForId.Gender = employee.Gender;
            employeeForId.ImageUrl = employee.ImageUrl;
            employeeForId.Function = employee.Function;

            _dbContext.Employees.Update(employeeForId);
            await _dbContext.SaveChangesAsync();
            return employeeForId;
        }

        public async Task<bool> Delete(int id)
        {
            Employee employeeForId = await GetForId(id);
            if (employeeForId == null)
            {
                throw new Exception($"Customer ID:{id} Not found in DB!");
            }
            _dbContext.Employees.Remove(employeeForId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }
}
