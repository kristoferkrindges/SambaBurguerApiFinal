using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SambaBurguer.Models;
using SambaBurguer.Repository;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllCustomers()
        {
            List<Employee> employees = await _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetForId(int id)
        {
            Employee employees = await _employeeRepository.GetForId(id);
            return Ok(employees);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Add([FromBody] Employee employee)
        {
            Employee newEmployee = await _employeeRepository.Add(employee);
            return Ok(newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Update([FromBody] Employee employee, int id)
        {
            employee.Id = id;
            Employee newEmployee = await _employeeRepository.Update(employee, id);
            return Ok(newEmployee);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            bool del = await _employeeRepository.Delete(id);
            return Ok(del);
        }
    }
}
