using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCDEMO.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Display(Name = "ID")]
        public string ProductID { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Giá")]
        public string UnitPrice { get; set; }
        [Display(Name = "Số Lượng")]

        public string Quantity { get; set; }
    }
}