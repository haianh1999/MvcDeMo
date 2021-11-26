using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MVCDEMO.Models 
{
    [Table("Chidoans")]
    public class Chidoan {
        [Key]
        public string cdid { get; set; }
        public string tenchidoan { get; set; }
    }
}