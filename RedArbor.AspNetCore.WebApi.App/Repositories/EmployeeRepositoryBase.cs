using RedArbor.AspNetCore.WebApi.App.Models;
using RedArbor.AspNetCore.WebApi.App.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RedArbor.AspNetCore.WebApi.App.Repositories
{
    public class EmployeeRepositoryBase
    {
        protected async Task<IEnumerable<Employee>> GetEmployeesOfSp(SqlDataReader rdr)
        {
            List<Employee> lstEmployee = new List<Employee>();

            while (await rdr.ReadAsync())
            {
                Employee employee = GetEmployeeOfSp(rdr);
                lstEmployee.Add(employee);
            }

            return lstEmployee;
        }

        protected Employee GetEmployeeOfSp(SqlDataReader rdr)
        {
            Employee employee = new Employee()
            {
                CompanyId = Convert.ToInt32(rdr[Constants.COMPANY_ID_FIELD]),
                CreatedOn = Convert.ToDateTime(rdr[Constants.CREATED_ON_FIELD]),
                DeletedOn = Convert.ToDateTime(rdr[Constants.DELETED_ON_FIELD]),
                Email = rdr[Constants.EMAIL_FIELD].ToString(),
                Fax = rdr[Constants.FAX_FIELD].ToString(),
                Name = rdr[Constants.NAME_FIELD].ToString(),
                LastLogin = Convert.ToDateTime(rdr[Constants.LAST_LOGIN_FIELD]),
                Password = rdr[Constants.PASSWORD_FIELD].ToString(),
                PortalId = Convert.ToInt32(rdr[Constants.PORTAL_ID_FIELD]),
                RoleId = Convert.ToInt32(rdr[Constants.ROLE_ID_FIELD]),
                StatusId = Convert.ToInt32(rdr[Constants.STATUS_ID_FIELD]),
                Telephone = rdr[Constants.TELEPHONE_FIELD].ToString(),
                UpdatedOn = Convert.ToDateTime(rdr[Constants.UPDATED_ON_FIELD]),
                Username = rdr[Constants.USERNAME_FIELD].ToString(),
            };

            return employee;
        }

        protected void AddAllParametersSP(ref SqlCommand cmd, Employee employee)
        {
            cmd.Parameters.AddWithValue(Constants.COMPANY_ID_PARAM, employee.CompanyId);
            cmd.Parameters.AddWithValue(Constants.CREATED_ON_PARAM, employee.CreatedOn);
            cmd.Parameters.AddWithValue(Constants.DELETED_ON_PARAM, employee.DeletedOn);
            cmd.Parameters.AddWithValue(Constants.EMAIL_PARAM, employee.Email);
            cmd.Parameters.AddWithValue(Constants.FAX_PARAM, employee.Fax);
            cmd.Parameters.AddWithValue(Constants.NAME_PARAM, employee.Name);
            cmd.Parameters.AddWithValue(Constants.LAST_LOGIN_PARAM, employee.LastLogin);
            cmd.Parameters.AddWithValue(Constants.PASSWORD_PARAM, employee.Password);
            cmd.Parameters.AddWithValue(Constants.PORTAL_ID_PARAM, employee.PortalId);
            cmd.Parameters.AddWithValue(Constants.ROLE_ID_PARAM, employee.RoleId);
            cmd.Parameters.AddWithValue(Constants.STATUS_ID_PARAM, employee.StatusId);
            cmd.Parameters.AddWithValue(Constants.TELEPHONE_PARAM, employee.Telephone);
            cmd.Parameters.AddWithValue(Constants.UPDATED_ON_PARAM, employee.UpdatedOn);
            cmd.Parameters.AddWithValue(Constants.USERNAME_PARAM, employee.Username);
        }
    }
}
