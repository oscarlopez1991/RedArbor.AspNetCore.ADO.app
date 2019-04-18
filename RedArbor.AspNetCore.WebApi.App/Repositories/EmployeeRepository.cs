using Microsoft.Extensions.Configuration;
using RedArbor.AspNetCore.WebApi.App.Models;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using RedArbor.AspNetCore.WebApi.App.Utils;

namespace RedArbor.AspNetCore.WebApi.App.Repositories
{
    public class EmployeeRepository : EmployeeRepositoryBase, IEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            using (SqlConnection con = new SqlConnection(this._configuration.GetConnectionString(Constants.CONNECTION_STRING)))
            {
                SqlCommand cmd = new SqlCommand(Constants.SP_GET_ALL_EMPLOYEES, con);
                cmd.CommandType = CommandType.StoredProcedure;

                await con.OpenAsync();

                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                List<Employee> lstEmployee = new List<Employee>(await GetEmployeesOfSp(rdr));

                con.Close();

                return lstEmployee;
            }            
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            using (SqlConnection con = new SqlConnection(this._configuration.GetConnectionString(Constants.CONNECTION_STRING)))
            {
                SqlCommand cmd = new SqlCommand(Constants.SP_GET_EMPLOYEE, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Constants.COMPANY_ID_PARAM, id);

                await con.OpenAsync();

                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                Employee employee = null;

                if (rdr.HasRows)
                {
                    await rdr.ReadAsync();
                    employee = GetEmployeeOfSp(rdr);
                }

                con.Close();

                return employee;
            }
        }

        public async Task AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(this._configuration.GetConnectionString(Constants.CONNECTION_STRING)))
            {
                SqlCommand cmd = new SqlCommand(Constants.SP_ADD_EMPLOYEE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                AddAllParametersSP(ref cmd, employee);

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(this._configuration.GetConnectionString(Constants.CONNECTION_STRING)))
            {
                SqlCommand cmd = new SqlCommand(Constants.SP_UPDATE_EMPLOYEE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                AddAllParametersSP(ref cmd, employee);

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }

        public async Task DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(this._configuration.GetConnectionString(Constants.CONNECTION_STRING)))
            {
                SqlCommand cmd = new SqlCommand(Constants.SP_DELETE_EMPLOYEE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(Constants.COMPANY_ID_PARAM, id);

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }              
    }
}
