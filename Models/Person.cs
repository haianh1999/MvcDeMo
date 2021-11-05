
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCDEMO.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [Display(Name = "ID")]
        public string PersonID { get; set; }
        [Display(Name = "Tên")]
        public string PersonName { get; set; }
    }
}
                                