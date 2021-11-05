using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCDEMO.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
