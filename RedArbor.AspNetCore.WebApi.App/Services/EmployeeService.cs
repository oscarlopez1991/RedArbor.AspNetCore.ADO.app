using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RedArbor.AspNetCore.WebApi.App.Models;
using RedArbor.AspNetCore.WebApi.App.Repositories;

namespace RedArbor.AspNetCore.WebApi.App.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this._employeeRepository = employeeRepository;
            this._mapper = mapper;
        }        

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            IEnumerable<Employee> listEmployee = await _employeeRepository.GetAllEmployees();

            var listEmployeeDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(listEmployee);
            return listEmployeeDTO;
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            Employee employee = await _employeeRepository.GetEmployeeById(id);

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return employeeDTO;
        }

        public async Task AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);

            await _employeeRepository.AddEmployee(employee);
        }

        public async Task<bool> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            bool updated = false;
            var employee = _mapper.Map<Employee>(employeeDTO);

            Employee checkEmployee = await _employeeRepository.GetEmployeeById(id);

            if (checkEmployee != null)
            {
                await _employeeRepository.UpdateEmployee(employee);
                updated = true;
            }

            return updated;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            bool deleted = false;

            Employee checkEmployee = await _employeeRepository.GetEmployeeById(id);

            if (checkEmployee != null)
            {
                await _employeeRepository.DeleteEmployee(id);
                deleted = true;
            }

            return deleted;
        }        
    }
}
