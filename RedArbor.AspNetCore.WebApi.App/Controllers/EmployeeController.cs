﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedArbor.AspNetCore.WebApi.App.Models;
using RedArbor.AspNetCore.WebApi.App.Services;

namespace RedArbor.AspNetCore.WebApi.App.Controllers
{
    [Route("api/redarbor")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _serviceEmployee;

        public EmployeeController(IEmployeeService serviceEmployee)
        {
            this._serviceEmployee = serviceEmployee;
        }

        // GET api/redarbor
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<EmployeeDTO>> GetAsync()
        {
            return await _serviceEmployee.GetAllEmployees();
        }

        // GET api/redarbor/1
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public async Task<ActionResult<EmployeeDTO>> GetByIdAsync(int id)
        {
            var employeeDTO = await _serviceEmployee.GetEmployeeById(id);

            if (employeeDTO == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(employeeDTO);
        }

        // POST api/redarbor
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EmployeeDTO>> PostAsync([FromBody] EmployeeDTO employeeDTO)
        {
            await _serviceEmployee.AddEmployee(employeeDTO);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = employeeDTO.CompanyId }, employeeDTO);
        }

        // PUT api/redarbor/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            bool updated = await _serviceEmployee.UpdateEmployee(id, employeeDTO);

            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE api/redarbor/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool deleted = await _serviceEmployee.DeleteEmployee(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
