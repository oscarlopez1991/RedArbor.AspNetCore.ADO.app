using System;
using System.ComponentModel.DataAnnotations;

namespace RedArbor.AspNetCore.WebApi.App.Models
{
    public class EmployeeDTO
    {
        [Key]   
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime DeletedOn { get; set; }
        [Required]
        [MaxLength(50), MinLength(5)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Fax { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime LastLogin { get; set; }
        [Required]
        [MaxLength(20), MinLength(5)]
        public string Password { get; set; }
        [Required]
        public int PortalId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        [Phone]
        [MaxLength(11)]
        public string Telephone { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        [MaxLength(50), MinLength(5)]
        public string Username { get; set; }
    }
}
