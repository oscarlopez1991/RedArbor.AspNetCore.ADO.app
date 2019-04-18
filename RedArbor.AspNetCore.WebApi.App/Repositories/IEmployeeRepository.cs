using RedArbor.AspNetCore.WebApi.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedArbor.AspNetCore.WebApi.App.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task AddEmployee(Employee employee);

        Task UpdateEmployee(Employee employee);

        Task DeleteEmployee(int id);
    }
}
