using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        public bool Status { get; set; }
    }
}
