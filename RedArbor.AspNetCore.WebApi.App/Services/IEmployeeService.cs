using RedArbor.AspNetCore.WebApi.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedArbor.AspNetCore.WebApi.App.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();

        Task<EmployeeDTO> GetEmployeeById(int id);

        Task AddEmployee(EmployeeDTO employeeDTO);

        Task<bool> UpdateEmployee(int id, EmployeeDTO employeeDTO);

        Task<bool> DeleteEmployee(int id);        
    }
}
