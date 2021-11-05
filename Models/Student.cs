using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCDEMO.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Display(Name = "ID")]

        public string StudentId { get; set; }
        [Display(Name = "Tên Sinh Viên")]

        public string StudentName { get; set; }
        [Display(Name = "Địa Chỉ")]

        public string address { get; set; }
    }
}